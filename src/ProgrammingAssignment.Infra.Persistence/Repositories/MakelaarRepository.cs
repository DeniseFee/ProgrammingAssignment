using ProgrammingAssignment.Domain.Makelaar;

namespace ProgrammingAssignment.Infra.Persistence.Repositories;
internal class MakelaarRepository(ProgrammingAssignmentContext context) : IMakelaarRepository
{
    private readonly ProgrammingAssignmentContext _context = context;

    public async Task SaveMakelaarTopListAsync(List<Makelaar> makelaars)
    {
        _context.Makelaars.RemoveRange(_context.Makelaars);

        await _context.Makelaars.AddRangeAsync(makelaars);
        await _context.SaveChangesAsync();
    }
}
