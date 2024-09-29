using System.ComponentModel.DataAnnotations;

namespace ProgrammingAssignment.Domain.Makelaar;

public class Makelaar
{
    [Key]
    public int Id { get; init; }
    public int FundaId { get; init; }
    public string? Naam { get; set; }
    public int AantalWoningen { get; init; }
    public MakelaarToplijstType TopLijstType{ get; init; }
}
