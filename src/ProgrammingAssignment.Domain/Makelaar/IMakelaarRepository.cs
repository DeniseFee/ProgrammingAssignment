namespace ProgrammingAssignment.Domain.Makelaar;

public interface IMakelaarRepository
{
    public Task SaveMakelaarTopListAsync(List<Makelaar> makelaars);
}
