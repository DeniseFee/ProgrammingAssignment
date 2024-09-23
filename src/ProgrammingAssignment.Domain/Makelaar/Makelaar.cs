using System.ComponentModel.DataAnnotations;

namespace ProgrammingAssignment.Domain.Makelaar;

public class Makelaar
{
    // Todo: lokale key maken
    [Key]
    public int FundaId { get; set; }
    public string Naam { get; set; }
    public int AantalWoningen { get; set; }
}
