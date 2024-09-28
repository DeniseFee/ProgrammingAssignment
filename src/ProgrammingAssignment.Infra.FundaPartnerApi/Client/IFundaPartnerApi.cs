using ProgrammingAssignment.Application.Woningen;
using Refit;

namespace ProgrammingAssignment.Infra.FundaPartnerApi.Client
{
    public interface IFundaPartnerApi
    {
        [Get("/{apiKey}/?type=koop&zo=/{plaats}&page={page}&pagesize={pagesize}")]
        Task<string> GetKoopwoningenVoorPlaatsAsync(string apiKey, string plaats, int page, int pagesize);

        [Get("/{plaats}/tuin")]
        Task<List<WoningDto>> GetKoopwoningenVoorPlaatsMetTuinAsync(string plaats);
    }
}
