﻿using AutoMapper;
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

        var woningen = await fundaWoningenService.GetKoopwoningenVoorPlaatsAsync(plaats);
        var teKoopWoningen = woningen.Where(w => w.IsTeKoop);

        var topMakelaarList = teKoopWoningen
            .GroupBy(w => new { w.MakelaarFundaId, w.MakelaarNaam })
            .Select(g => new MakelaarDto
            {
                FundaId = g.Key.MakelaarFundaId,
                Naam = g.Key.MakelaarNaam,
                AantalWoningen = g.Count(),
                ToplijstType = MakelaarToplijstType.ZonderTuin
            })
            .OrderByDescending(m => m.AantalWoningen)
            .Take(10)
            .ToList();

        await makelaarRepository.SaveMakelaarTopListAsync(mapper.Map<List<Makelaar>>(topMakelaarList));

        return topMakelaarList;
    }
    
    public async Task<List<MakelaarDto>> ProcessMakelaarsTopListWithTuinAsync(string plaats)
    {
        logger.LogInformation("Start met verwerken van top makelaarslijst voor plaats met tuin {Plaats}", plaats);

        var woningen = await fundaWoningenService.GetKoopwoningenVoorPlaatsMetTuinAsync(plaats);
        var teKoopWoningen = woningen.Where(w => w.IsTeKoop);

        var topMakelaarList = teKoopWoningen
            .GroupBy(w => new { w.MakelaarFundaId, w.MakelaarNaam })
            .Select(g => new MakelaarDto
            {
                FundaId = g.Key.MakelaarFundaId,
                Naam = g.Key.MakelaarNaam,
                AantalWoningen = g.Count(),
                ToplijstType = MakelaarToplijstType.MetTuin
            })
            .OrderByDescending(m => m.AantalWoningen)
            .Take(10)
            .ToList();

        await makelaarRepository.SaveMakelaarTopListAsync(mapper.Map<List<Makelaar>>(topMakelaarList));

        return topMakelaarList;
    }
}