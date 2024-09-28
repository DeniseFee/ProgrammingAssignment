namespace ProgrammingAssignment.Application.Woningen;

public interface IKoopwoningenService
{
    public Task<List<WoningDto>> GetKoopwoningenVoorPlaatsAsync(string plaats);
    public Task<List<WoningDto>> GetKoopwoningenVoorPlaatsMetTuinAsync(string plaats);
}
