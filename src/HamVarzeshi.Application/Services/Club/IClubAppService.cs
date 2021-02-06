using System;
using Abp.Application.Services;
using HamVarzeshi.Application.Services.Club.Dto;

namespace HamVarzeshi.Application.Services.Club
{
    public interface IClubAppService : IAsyncCrudAppService<ClubDto, Guid>
    {

    }
}