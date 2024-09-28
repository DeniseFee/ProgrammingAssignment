using Microsoft.Extensions.DependencyInjection;
using ProgrammingAssignment.Application.Woningen;
using Refit;

namespace ProgrammingAssignment.Infra.FundaPartnerApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddFundaPartnerApiServices(this IServiceCollection services)
        {
            // amsterdam/tuin/&page=1&p
            var serviceUrl = "http://partnerapi.funda.nl/feeds/Aanbod.svc/json/[key]/?type=koop&zo=/";
             services.AddScoped<IKoopwoningenService, KoopwoningenService>()
                .AddRefitClient<IFundaPartnerApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(serviceUrl));

            return services;
        }
    }
}
