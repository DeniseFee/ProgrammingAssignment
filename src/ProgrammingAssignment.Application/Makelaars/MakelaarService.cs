using AutoMapper;
using Microsoft.Extensions.Logging;
using ProgrammingAssignment.Application.Woningen;
using ProgrammingAssignment.Domain.Makelaar;

namespace ProgrammingAssignment.Application.Makelaars;

public class MakelaarService(
    IMakelaarRepository makelaarRepository,
    IKoopwoningenService fundaWoningenService,
    IMapper mapper,
    ILogger<MakelaarService> logger) : IMakelaarService
{
    public async Task<List<MakelaarDto>> ProcessMakelaarsTopListAsync(string plaats)
    {
        logger.LogInformation("Start met verwerken van top makelaarslijst voor plaats {Plaats}", plaats);

        var alleWoningen = await fundaWoningenService.GetKoopwoningenVoorPlaatsAsync(plaats);
        var teKoopWoningen = alleWoningen.Where(w => w.IsTeKoop);

        var topMakelaarList = GetTopMakelaarLijst(teKoopWoningen);

        await makelaarRepository.SaveMakelaarTopListAsync(mapper.Map<List<Makelaar>>(topMakelaarList));

        return topMakelaarList;
    }

    private static List<MakelaarDto> GetTopMakelaarLijst(IEnumerable<WoningDto> teKoopWoningen)
    {
        return teKoopWoningen
            .GroupBy(w => new { w.MakelaarFundaId, w.MakelaarNaam })
            .Select(g => new MakelaarDto
            {
                FundaId = g.Key.MakelaarFundaId,
                Naam = g.Key.MakelaarNaam,
                AantalWoningen = g.Count()
            })
            .OrderByDescending(m => m.AantalWoningen)
            .Take(10)
            .ToList();
    }
}