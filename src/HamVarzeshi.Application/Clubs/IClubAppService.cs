using System;
using Abp.Application.Services;
using HamVarzeshi.Clubs.Dto;

namespace HamVarzeshi.Clubs
{
    public interface IClubAppService : IAsyncCrudAppService<ClubDto, Guid, PagedClubResultRequestDto, CreateClubDto, ClubDto>
    {

    }
}