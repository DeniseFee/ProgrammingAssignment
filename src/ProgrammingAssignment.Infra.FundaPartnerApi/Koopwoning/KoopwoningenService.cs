using System.Net;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProgrammingAssignment.Application.Woningen;
using ProgrammingAssignment.Infra.FundaPartnerApi.Client;
using Refit;

namespace ProgrammingAssignment.Infra.FundaPartnerApi.Koopwoning;

public class KoopwoningenService(
    IFundaPartnerApi fundaPartnerApi,
    IConfiguration configuration,
    IMapper mapper,
    ILogger<KoopwoningenService> logger)
    : IKoopwoningenService
{
    private readonly string _apiKey = configuration["PartnerApiKey"] ?? throw new InvalidOperationException("API key not found in configuration.");
    private readonly TimeSpan _initialRetryDelay = TimeSpan.FromSeconds(2);
    private readonly int _maxRetryAttempts = 3;

    public async Task<List<WoningDto>> GetKoopwoningenVoorPlaatsAsync(string plaats)
    {
        return await ExecuteWithRetryPolicy(async () => await HaalKoopwoningenOp(plaats, withTuin: false));
    }
    
    public async Task<List<WoningDto>> GetKoopwoningenVoorPlaatsMetTuinAsync(string plaats)
    {
        return await ExecuteWithRetryPolicy(async () => await HaalKoopwoningenOp(plaats, withTuin: true));
    }

    private async Task<List<WoningDto>> HaalKoopwoningenOp(string plaats, bool withTuin)
    {
        var allWoningen = new List<WoningDto>();
        var currentPage = 1;
        KoopwoningenResponse? response;

        do
        {
            string jsonResponse = withTuin
                ? await fundaPartnerApi.GetKoopwoningenVoorPlaatsMetTuinAsync(_apiKey, plaats, currentPage, 50)
                : await fundaPartnerApi.GetKoopwoningenVoorPlaatsAsync(_apiKey, plaats, currentPage, 50);

            response = JsonConvert.DeserializeObject<KoopwoningenResponse>(jsonResponse);

            if (response?.Objects != null)
            {
                var woningenDtos = mapper.Map<List<WoningDto>>(response.Objects);
                allWoningen.AddRange(woningenDtos);
            }

            currentPage++;
        } while (response != null && currentPage <= response.Paging?.AantalPaginas);

        return allWoningen;
    }

    private async Task<T> ExecuteWithRetryPolicy<T>(Func<Task<T>> action)
    {
        var attempt = 0;
        var delay = _initialRetryDelay;

        while (attempt < _maxRetryAttempts)
        {
            try
            {
                return await action();
            }
            catch (ApiException apiEx) when (apiEx.StatusCode == HttpStatusCode.TooManyRequests)
            {
                attempt++;
                if (attempt >= _maxRetryAttempts) throw;

                logger.LogWarning("Rate limit hit. Waiting for {delay} seconds before retrying...", delay.TotalSeconds);

                await Task.Delay(delay);
                delay = TimeSpan.FromSeconds(delay.TotalSeconds * 2);
            }
            catch (ApiException apiEx)
            {
                logger.LogError("API Error: {StatusCode}, Message: {Message}", apiEx.StatusCode, apiEx.Message);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError("Unexpected error: {Message}", ex.Message);
                throw;
            }
        }

        throw new InvalidOperationException("Maximum retry attempts exceeded.");
    }
}
