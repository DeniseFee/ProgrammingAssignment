using Microsoft.Extensions.Logging;
using ProgrammingAssignment.Domain.Makelaar;

namespace ProgrammingAssignment.Infra.Persistence.Repositories;

public class MakelaarRepository(ProgrammingAssignmentContext context, ILogger<MakelaarRepository> logger)
    : IMakelaarRepository
{
    public async Task SaveMakelaarTopListAsync(List<Makelaar> makelaars)
    {
        logger.LogInformation("Start wegschrijven van topmakelaarlijst {Lijst}", makelaars);
        context.Makelaars.RemoveRange(context.Makelaars.Where(makelaar => makelaar.TopLijstType == makelaars[0].TopLijstType));

        await context.Makelaars.AddRangeAsync(makelaars);
        await context.SaveChangesAsync();
    }
}