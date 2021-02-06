using System;
using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using HamVarzeshi.Application.Services.Club.Dto;
using HamVarzeshi.Authorization;

namespace HamVarzeshi.Application.Services.Club
{
    [AbpAuthorize(PermissionNames.Pages_Clubs)]
    public class ClubAppService : AsyncCrudAppService<Core.Domain.Club, ClubDto, Guid>, IClubAppService
    {
        public ClubAppService(IRepository<Core.Domain.Club, Guid> repository) : base(repository)
        {
        }
    }
}