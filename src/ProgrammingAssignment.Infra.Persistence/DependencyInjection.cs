using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ProgrammingAssignment.Domain.Makelaar;
using ProgrammingAssignment.Infra.Persistence.Repositories;

namespace ProgrammingAssignment.Infra.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddScoped<IMakelaarRepository, MakelaarRepository>()
                .AddDbContext<ProgrammingAssignmentContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("ProgrammingAssignment"))); ;
        }
    }
}
