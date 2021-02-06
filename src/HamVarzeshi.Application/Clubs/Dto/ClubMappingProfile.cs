using AutoMapper;

namespace HamVarzeshi.Clubs.Dto
{
    public class ClubMappingProfile : Profile
    {
        public ClubMappingProfile()
        {
            CreateMap<ClubDto, Core.Domain.Club>();
        }
    }
}