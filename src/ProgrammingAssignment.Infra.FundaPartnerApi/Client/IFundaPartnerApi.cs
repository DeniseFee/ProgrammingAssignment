using ProgrammingAssignment.Application.Woningen;
using Refit;

namespace ProgrammingAssignment.Infra.FundaPartnerApi.Client
{
    public interface IFundaPartnerApi
    {
        [Get("/{apiKey}/?type=koop&zo=/{plaats}")]
        Task<List<WoningDto>> GetKoopwoningenVoorPlaatsAsync(string apiKey, string plaats);

        [Get("/{plaats}/tuin")]
        Task<List<WoningDto>> GetKoopwoningenVoorPlaatsMetTuinAsync(string plaats);
    }
}
