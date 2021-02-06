using AutoMapper;
using HamVarzeshi.Core.Domain;

namespace HamVarzeshi.ClubSessionRegisters.Dto
{
    public class ClubSessionRegisterMappingProfile : Profile
    {
        public ClubSessionRegisterMappingProfile()
        {
            CreateMap<ClubSessionRegisterDto, ClubSessionRegister>();                
        }
    }
}