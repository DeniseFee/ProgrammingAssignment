using Microsoft.Extensions.DependencyInjection;
using ProgrammingAssignment.Application.Woningen;
using ProgrammingAssignment.Infra.FundaPartnerApi.Client;
using Refit;

namespace ProgrammingAssignment.Infra.FundaPartnerApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddFundaPartnerApiServices(this IServiceCollection services)
        {
            var serviceUrl = $"http://partnerapi.funda.nl/feeds/Aanbod.svc/json/";
             services.AddScoped<IKoopwoningenService, KoopwoningenService>()
                .AddRefitClient<IFundaPartnerApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(serviceUrl));

            return services;
        }
    }
}
