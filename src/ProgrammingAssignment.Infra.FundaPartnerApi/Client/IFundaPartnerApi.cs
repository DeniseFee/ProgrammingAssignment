using ProgrammingAssignment.Application.Woningen;
using Refit;

namespace ProgrammingAssignment.Infra.FundaPartnerApi.Client
{
    public interface IFundaPartnerApi
    {
        [Get("/{apiKey}/?type=koop&zo=/{plaats}&page={page}&pagesize={pagesize}")]
        Task<string> GetKoopwoningenVoorPlaatsAsync(string apiKey, string plaats, int page, int pagesize);
        
        [Get("/{apiKey}/?type=koop&zo=/{plaats}/tuin/&page={page}&pagesize={pagesize}")]
        Task<string> GetKoopwoningenVoorPlaatsMetTuinAsync(string apiKey, string plaats, int page, int pagesize);
    }
}
