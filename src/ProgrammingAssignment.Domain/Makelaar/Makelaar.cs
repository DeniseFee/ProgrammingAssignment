using System.ComponentModel.DataAnnotations;

namespace ProgrammingAssignment.Domain.Makelaar;

public class Makelaar
{
    [Key]
    public int Id { get; set; }
    public int FundaId { get; set; }
    public string Naam { get; set; }
    public int AantalWoningen { get; set; }
}
