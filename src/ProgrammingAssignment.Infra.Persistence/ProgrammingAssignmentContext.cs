using Microsoft.EntityFrameworkCore;
using ProgrammingAssignment.Domain.Makelaar;
using System.Reflection;

namespace ProgrammingAssignment.Infra.Persistence;

public class ProgrammingAssignmentContext(DbContextOptions<ProgrammingAssignmentContext> options) : DbContext(options)
{
    public DbSet<Makelaar> Makelaars { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
