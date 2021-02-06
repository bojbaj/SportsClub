using AutoMapper;
using HamVarzeshi.Core.Domain;

namespace HamVarzeshi.ClubSessions.Dto
{
    public class ClubSessionMappingProfile : Profile
    {
        public ClubSessionMappingProfile()
        {
            CreateMap<ClubSessionDto, ClubSession>();                
        }
    }
}