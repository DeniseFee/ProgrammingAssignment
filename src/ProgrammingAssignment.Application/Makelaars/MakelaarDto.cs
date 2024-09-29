namespace ProgrammingAssignment.Application.Makelaars;

public class MakelaarDto
{
    public int FundaId { get; init; }
    public string? Naam { get; init; }
    public int AantalWoningen { get; init; }
    public MakelaarToplijstType ToplijstType { get; init; }
}
