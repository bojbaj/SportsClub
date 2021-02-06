using System;
using Abp.Application.Services;
using HamVarzeshi.ClubSessions.Dto;

namespace HamVarzeshi.ClubSessions
{
    public interface IClubSessionAppService : IAsyncCrudAppService<ClubSessionDto, Guid, PagedClubSessionResultRequestDto, CreateClubSessionDto, ClubSessionDto>
    {

    }
}