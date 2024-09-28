using ProgrammingAssignment.Application.Woningen;
using Refit;

namespace ProgrammingAssignment.Infra.FundaPartnerApi;

public class KoopwoningenService(IFundaPartnerApi fundaPartnerApi) : IKoopwoningenService
{
    public async Task<List<WoningDto>> GetKoopwoningenVoorPlaatsAsync(string plaats)
    {
        try
        {
            return await fundaPartnerApi.GetKoopwoningenVoorPlaatsAsync(plaats);
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

