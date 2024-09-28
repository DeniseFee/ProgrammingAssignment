using AutoMapper;
using ProgrammingAssignment.Domain.Makelaar;

namespace ProgrammingAssignment.Application.Makelaars;

public class MakelaarMappingProfile: Profile
{
    public MakelaarMappingProfile()
    {
        CreateMap<Makelaar, MakelaarDto>();
        CreateMap<MakelaarDto, Makelaar>();
    }
}