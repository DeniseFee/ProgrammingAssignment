using Microsoft.Extensions.DependencyInjection;
using ProgrammingAssignment.Application.Woningen;

namespace ProgrammingAssignment.Infra.FundaPartnerApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddFundaPartnerApiServices(this IServiceCollection services)
        {
            return services.AddScoped<IFundaWoningenService, FundaWoningenService>();
        }
    }
}
