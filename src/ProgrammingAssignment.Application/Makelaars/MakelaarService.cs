using Microsoft.Extensions.Logging;
using ProgrammingAssignment.Application.Woningen;
using ProgrammingAssignment.Domain.Makelaar;

namespace ProgrammingAssignment.Application.Makelaars;

public class MakelaarService(IMakelaarRepository makelaarRepository, IKoopwoningenService fundaWoningenService, ILogger<MakelaarService> logger) : IMakelaarService
{
    private IMakelaarRepository _makelaarRepository { get; set; } = makelaarRepository;
    private IKoopwoningenService _fundaWoningenService { get; set; } = fundaWoningenService;
    private ILogger<MakelaarService> _logger { get; set; } = logger;

    public async Task<List<Makelaar>> ProcessMakelaarsTopListAsync(string plaats)
    {
        _logger.LogInformation("Start met verwerken van top makelaarslijst voor plaats {Plaats}", plaats);

        var woningen = await _fundaWoningenService.GetKoopwoningenVoorPlaatsAsync(plaats);
        //todo: verder specificeren woningen voordat de call gedaan gaat worden naar API
        var teKoopWoningen = woningen.Where(w => w.IsTeKoop).ToList();

        _logger.LogInformation("{WoningenAantal} woningen sorteren per makelaar", teKoopWoningen.Count);
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

        _logger.LogInformation("Start wegschrijven van topmakelaatlijst {lijst}", topMakelaarList);
        await _makelaarRepository.SaveMakelaarTopListAsync(topMakelaarList);

        return topMakelaarList;
    }
}
