using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using HamVarzeshi.Clubs.Dto;
using HamVarzeshi.ClubSessionRegisters.Dto;
using HamVarzeshi.ClubSessions.Dto;

namespace HamVarzeshi.ClubSessionRegisters
{
    public interface IClubSessionRegisterAppService : IAsyncCrudAppService<ClubSessionRegisterDto, Guid, PagedClubSessionRegisterResultRequestDto, CreateClubSessionRegisterDto, ClubSessionRegisterDto>
    {
        Task<ListResultDto<ClubDto>> GetClubs();
        Task<PagedResultDto<ClubSessionForUserDto>> GetClubSessions(PagedClubSessionResultRequestDto input);

    }
}