using ProgrammingAssignment.Domain.Makelaar;

namespace ProgrammingAssignment.Application.Makelaars;

public interface IMakelaarService
{
    public Task<List<Makelaar>> ProcessMakelaarsTopListAsync();
}
