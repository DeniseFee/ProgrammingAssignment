using ProgrammingAssignment.Application.Woningen;

namespace ProgrammingAssignment.Infra.FundaPartnerApi;

public class FundaWoningenService : IFundaWoningenService
{
    public List<WoningDto> GetWoningenAsync()
    {
        return new List<WoningDto>
        {
            new(){MakelaarFundaId= 1234, MakelaarNaam= "TestNaam", IsTeKoop =  true }
        };
    }
}
