using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NSubstitute;
using ProgrammingAssignment.Domain.Makelaar;
using ProgrammingAssignment.Infra.Persistence.Repositories;

namespace ProgrammingAssignment.Infra.Persistence.Tests.Uit;

public class MakelaarRepositoryTests
{
    private readonly ProgrammingAssignmentContext _context;
    private readonly ILogger<MakelaarRepository> _logger;
    private readonly DbSet<Makelaar> _dbSet;
    private readonly MakelaarRepository _repository;
    
    public MakelaarRepositoryTests()
    {
        _context = Substitute.For<ProgrammingAssignmentContext>();
        _logger = Substitute.For<ILogger<MakelaarRepository>>();
        _dbSet = Substitute.For<DbSet<Makelaar>>();
        _repository = new MakelaarRepository(_context, _logger);
    }
    
    [Fact]
    public async Task SaveMakelaarTopListAsync_ShouldSaveMakelaarTopList()
    {
        // Arrange
        var topLijstType = MakelaarToplijstType.MetTuin;
        var makelaars = new List<Makelaar> 
        { 
            new() { Id = 1, Naam = "Makelaar1", TopLijstType = topLijstType } 
        };

        _context.Makelaars.Returns(_dbSet);

        var repository = new MakelaarRepository(_context, _logger);

        // Act
        await repository.SaveMakelaarTopListAsync(makelaars);

        // Assert
        _dbSet.Received(1)
            .RemoveRange(Arg.Is<IEnumerable<Makelaar>>(m => m.All(makelaar => makelaar.TopLijstType == topLijstType)));
    }
    
    [Fact]
    public async Task SaveMakelaarTopListWithTuinAsync_ShouldSaveMakelaarWithTuinTopList()
    {
        // Arrange
        var makelaars = new List<Makelaar> { new Makelaar { Id = 2, Naam = "Makelaar2" } };

        _context.Makelaars.Returns(_dbSet);

        var repository = new MakelaarRepository(_context, _logger);

        // Act
        await repository.SaveMakelaarTopListAsync(makelaars);

        // Assert
        _dbSet.Received(1).RemoveRange(_dbSet);
        await _dbSet.Received(1).AddRangeAsync(makelaars);
        await _context.Received(1).SaveChangesAsync();
    }
}