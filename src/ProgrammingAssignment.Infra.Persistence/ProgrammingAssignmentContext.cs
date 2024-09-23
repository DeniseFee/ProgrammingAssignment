using Microsoft.EntityFrameworkCore;
using ProgrammingAssignment.Domain.Makelaar;

namespace ProgrammingAssignment.Infra.Persistence;

public class ProgrammingAssignmentContext(DbContextOptions<ProgrammingAssignmentContext> options) : DbContext(options)
{
    public DbSet<Makelaar> Makelaars { get; set; }
}
