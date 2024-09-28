using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using ProgrammingAssignment.Application.Woningen;
using ProgrammingAssignment.Infra.FundaPartnerApi.Client;
using ProgrammingAssignment.Infra.FundaPartnerApi.Koopwoning;
using Refit;

namespace ProgrammingAssignment.Infra.FundaPartnerApi;

public static class DependencyInjection
{
    public static IServiceCollection AddFundaPartnerApiServices(this IServiceCollection services)
    {
        var serviceUrl = "http://partnerapi.funda.nl/feeds/Aanbod.svc/json/";
        services.AddScoped<IKoopwoningenService, KoopwoningenService>()
            .AddAutoMapper(typeof(KoopwoningenMappingProfile))
            .AddRefitClient<IFundaPartnerApi>(provider =>
                new RefitSettings
                {
                    ContentSerializer = new NewtonsoftJsonContentSerializer(
                        new JsonSerializerSettings
                        {
                            ContractResolver = new CamelCasePropertyNamesContractResolver(),
                            Converters = { new StringEnumConverter() }
                        })
                })
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(serviceUrl));

        return services;
    }
}