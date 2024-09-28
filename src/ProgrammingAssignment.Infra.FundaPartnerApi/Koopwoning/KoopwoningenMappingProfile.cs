using AutoMapper;
using ProgrammingAssignment.Application.Woningen;

namespace ProgrammingAssignment.Infra.FundaPartnerApi.Koopwoning;

public class KoopwoningenMappingProfile : Profile
{
    public KoopwoningenMappingProfile()
    {
        CreateMap<Objects, WoningDto>();
    }
}