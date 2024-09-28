using Microsoft.Extensions.Configuration;
using ProgrammingAssignment.Application.Woningen;
using ProgrammingAssignment.Infra.FundaPartnerApi.Client;
using Refit;

namespace ProgrammingAssignment.Infra.FundaPartnerApi;

public class KoopwoningenService(IFundaPartnerApi fundaPartnerApi, IConfiguration configuration) : IKoopwoningenService
{
    private readonly IFundaPartnerApi _fundaPartnerApi = fundaPartnerApi;
    private readonly IConfiguration _configuration = configuration;

    public async Task<List<WoningDto>> GetKoopwoningenVoorPlaatsAsync(string plaats)
    {
        var apiKey = _configuration["PartnerApiKey"] ?? throw new InvalidOperationException("PartnerApiKey");
        try
        {
            return await fundaPartnerApi.GetKoopwoningenVoorPlaatsAsync(apiKey, plaats);
        }
        catch (ApiException ex)
        {
            throw new NotImplementedException(ex.Message);
        }
    }

    public Task<List<WoningDto>> GetKoopwoningenVoorPlaatsMetTuinAsync(string plaats)
    {
        throw new NotImplementedException();
    }
}

