using Microsoft.Extensions.Logging;
using ProgrammingAssignment.Domain.Makelaar;

namespace ProgrammingAssignment.Infra.Persistence.Repositories;

internal class MakelaarRepository(ProgrammingAssignmentContext context, ILogger<MakelaarRepository> logger)
    : IMakelaarRepository
{
    public async Task SaveMakelaarTopListAsync(List<Makelaar> makelaars)
    {
        logger.LogInformation("Start wegschrijven van topmakelaarlijst {Lijst}", makelaars);
        context.Makelaars.RemoveRange(context.Makelaars);

        await context.Makelaars.AddRangeAsync(makelaars);
        await context.SaveChangesAsync();
    }
}