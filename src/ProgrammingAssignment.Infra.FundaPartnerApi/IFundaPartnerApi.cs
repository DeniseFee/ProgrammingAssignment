using ProgrammingAssignment.Application.Woningen;
using Refit;

namespace ProgrammingAssignment.Infra.FundaPartnerApi
{
    public interface IFundaPartnerApi
    {
        [Get("/{plaats}")]
        Task<List<WoningDto>> GetKoopwoningenVoorPlaatsAsync(string plaats);

        [Get("/{plaats}/tuin")]
        Task<List<WoningDto>> GetKoopwoningenVoorPlaatsMetTuinAsync(string plaats);
    }
}
