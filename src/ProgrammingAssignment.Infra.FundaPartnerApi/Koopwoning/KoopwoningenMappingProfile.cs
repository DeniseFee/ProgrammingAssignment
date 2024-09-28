using AutoMapper;
using ProgrammingAssignment.Application.Woningen;

namespace ProgrammingAssignment.Infra.FundaPartnerApi.Koopwoning;

public class KoopwoningenMappingProfile : Profile
{
    public KoopwoningenMappingProfile()
    {
        CreateMap<Objects, WoningDto>()
            .ForMember(dest => dest.MakelaarFundaId, opt => opt.MapFrom(src => src.MakelaarId))
            .ForMember(dest => dest.IsTeKoop, opt => opt.MapFrom(src =>
                !(src.IsVerkocht ?? false) && !(src.IsVerhuurd ?? false) && !(src.IsVerkochtOfVerhuurd ?? false)));
    }
}