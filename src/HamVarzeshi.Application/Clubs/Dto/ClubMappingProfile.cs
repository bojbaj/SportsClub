using AutoMapper;
using HamVarzeshi.Core.Domain;

namespace HamVarzeshi.Clubs.Dto
{
    public class ClubMappingProfile : Profile
    {
        public ClubMappingProfile()
        {
            CreateMap<ClubDto, Club>();
        }
    }
}