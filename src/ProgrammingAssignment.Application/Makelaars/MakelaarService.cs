using ProgrammingAssignment.Application.Woningen;
using ProgrammingAssignment.Domain.Makelaar;

namespace ProgrammingAssignment.Application.Makelaars;

public class MakelaarService(IMakelaarRepository makelaarRepository, IKoopwoningenService fundaWoningenService) : IMakelaarService
{
    private IMakelaarRepository _makelaarRepository { get; set; } = makelaarRepository;
    private IKoopwoningenService _fundaWoningenService { get; set; } = fundaWoningenService;

    public async Task<List<Makelaar>> ProcessMakelaarsTopListAsync()
    {
        var woningen = await _fundaWoningenService.GetKoopwoningenVoorPlaatsAsync("Amsterdam");
        //todo: verder specificeren woningen voordat de call gedaan gaat worden naar API
        var teKoopWoningen = woningen.Where(w => w.IsTeKoop).ToList();

        var topMakelaarList = teKoopWoningen
            .GroupBy(w => new { w.MakelaarFundaId, w.MakelaarNaam })
            .Select(g => new Makelaar
            {
                FundaId = g.Key.MakelaarFundaId,
                Naam = g.Key.MakelaarNaam,
                AantalWoningen = g.Count()
            })
            .OrderByDescending(m => m.AantalWoningen)
            .Take(10)
            .ToList();

        await _makelaarRepository.SaveMakelaarTopListAsync(topMakelaarList);

        return topMakelaarList;
    }
}
