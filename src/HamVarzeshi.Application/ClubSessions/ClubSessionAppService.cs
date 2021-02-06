using System;
using System.Linq;
using Abp.Application.Services;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using HamVarzeshi.Authorization;
using HamVarzeshi.ClubSessions.Dto;
using HamVarzeshi.Core.Domain;

namespace HamVarzeshi.ClubSessions
{
    [AbpAuthorize(PermissionNames.Pages_Clubs)]
    public class ClubSessionAppService : AsyncCrudAppService<ClubSession, ClubSessionDto, Guid, PagedClubSessionResultRequestDto, CreateClubSessionDto, ClubSessionDto>, IClubSessionAppService
    {
        public ClubSessionAppService(IRepository<ClubSession, Guid> repository) : base(repository)
        {
        }

        protected override IQueryable<ClubSession> CreateFilteredQuery(PagedClubSessionResultRequestDto input)
        {
            return Repository.GetAll()
                .Where(x => input.Keyword.IsNullOrWhiteSpace() || x.Title.Contains(input.Keyword))
                .Where(x => !input.IsActive.HasValue || x.IsActive == input.IsActive);
        }

        protected override IQueryable<ClubSession> ApplySorting(IQueryable<ClubSession> query, PagedClubSessionResultRequestDto input)
        {
            return query.OrderBy(r => r.Title);
        }

    }
}