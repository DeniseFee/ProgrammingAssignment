using Microsoft.Extensions.DependencyInjection;
using ProgrammingAssignment.Application.Makelaars;

namespace ProgrammingAssignment.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services.AddScoped<IMakelaarService, MakelaarService>();
        }
    }
}
