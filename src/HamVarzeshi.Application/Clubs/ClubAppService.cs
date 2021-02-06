using System;
using System.Linq;
using Abp.Application.Services;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using HamVarzeshi.Authorization;
using HamVarzeshi.Clubs.Dto;
using HamVarzeshi.Core.Domain;

namespace HamVarzeshi.Clubs
{
    [AbpAuthorize(PermissionNames.Pages_Clubs)]
    public class ClubAppService : AsyncCrudAppService<Club, ClubDto, Guid, PagedClubResultRequestDto, CreateClubDto, ClubDto>, IClubAppService
    {
        public ClubAppService(IRepository<Club, Guid> repository) : base(repository)
        {
        }

        protected override IQueryable<Club> CreateFilteredQuery(PagedClubResultRequestDto input)
        {
            return Repository.GetAll()
                .Where(x => input.Keyword.IsNullOrWhiteSpace() || x.Title.Contains(input.Keyword))
                .Where(x => !input.IsActive.HasValue || x.IsActive == input.IsActive);
        }

        protected override IQueryable<Club> ApplySorting(IQueryable<Club> query, PagedClubResultRequestDto input)
        {
            return query.OrderBy(r => r.Title);
        }

    }
}