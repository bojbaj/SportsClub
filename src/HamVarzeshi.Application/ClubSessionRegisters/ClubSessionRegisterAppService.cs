using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using HamVarzeshi.Authorization;
using HamVarzeshi.Clubs.Dto;
using HamVarzeshi.ClubSessionRegisters.Dto;
using HamVarzeshi.ClubSessions.Dto;
using HamVarzeshi.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace HamVarzeshi.ClubSessionRegisters
{
    [AbpAuthorize]
    public class ClubSessionRegisterAppService : AsyncCrudAppService<ClubSessionRegister, ClubSessionRegisterDto, Guid, PagedClubSessionRegisterResultRequestDto, CreateClubSessionRegisterDto, ClubSessionRegisterDto>, IClubSessionRegisterAppService
    {
        private readonly IRepository<Club, Guid> _clubRepository;
        private readonly IRepository<ClubSession, Guid> _clubSessionRepository;

        public ClubSessionRegisterAppService(IRepository<ClubSessionRegister, Guid> repository, IRepository<Club, Guid> clubRepository, IRepository<ClubSession, Guid> clubSessionRepository) : base(repository)
        {
            _clubRepository = clubRepository;
            _clubSessionRepository = clubSessionRepository;
        }

        protected override IQueryable<ClubSessionRegister> CreateFilteredQuery(PagedClubSessionRegisterResultRequestDto input)
        {
            return Repository
                .GetAllIncluding(x => x.ClubSession, x => x.ClubSession.Club)
                .Where(x => input.Keyword.IsNullOrWhiteSpace() || x.ClubSession.Title.Contains(input.Keyword))
                .Where(x => input.UserId == 0 || x.RegisteredUserId == input.UserId);
        }

        protected override IQueryable<ClubSessionRegister> ApplySorting(IQueryable<ClubSessionRegister> query, PagedClubSessionRegisterResultRequestDto input)
        {
            return query.OrderBy(r => r.Id);
        }

        public async Task<ListResultDto<ClubDto>> GetClubs()
        {
            var clubs = await _clubRepository.GetAllListAsync();
            return new ListResultDto<ClubDto>(ObjectMapper.Map<List<ClubDto>>(clubs));
        }

        public async Task<PagedResultDto<ClubSessionForUserDto>> GetClubSessions(PagedClubSessionResultRequestDto input)
        {
            if (input.MaxResultCount <= 0)
                input.MaxResultCount = 10;

            if (input.SkipCount <= 0)
                input.SkipCount = 0;

            long currentUserId = Convert.ToInt64(AbpSession.UserId);

            var clubSessionsQuery = _clubSessionRepository
                .GetAllIncluding(x => x.Club)
                .Where(x => x.IsActive && x.Club.IsActive);

            var totalCount = await clubSessionsQuery.CountAsync();
            var items = await clubSessionsQuery
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .ToListAsync();

            var userRegistrations = await Repository
                .GetAllListAsync(x => x.RegisteredUserId == currentUserId);


            PagedResultDto<ClubSessionForUserDto> result = new PagedResultDto<ClubSessionForUserDto>();
            result.TotalCount = totalCount;

            var clubSessions = ObjectMapper.Map<List<ClubSessionForUserDto>>(items);
            clubSessions.Where(x => userRegistrations.Any(z => z.ClubSessionId == x.Id)).ToList().ForEach(x => x.Registered = true);
            result.Items = clubSessions;
            return result;
        }
        public async Task<Boolean> CancelRegistration(DeleteClubSessionRegisterDto input)
        {
            long currentUserId = Convert.ToInt64(AbpSession.UserId);
            await Repository
                .DeleteAsync(x => x.ClubSessionId.Equals(input.ClubSessionId) && x.RegisteredUserId == currentUserId);

            return true;
        }
        public async Task<Boolean> Register(CreateClubSessionRegisterDto input)
        {
            long currentUserId = Convert.ToInt64(AbpSession.UserId);

            var clubSessionRegister = await Repository
                .FirstOrDefaultAsync(x => x.ClubSessionId.Equals(input.ClubSessionId) && x.RegisteredUserId == currentUserId);

            if (clubSessionRegister == null)
            {
                var clubSession = await _clubSessionRepository
                    .GetAllIncluding(x => x.Club)
                    .FirstOrDefaultAsync(x => x.Id.Equals(input.ClubSessionId));

                if (clubSession != null)
                {
                    ClubSessionRegister entity = new ClubSessionRegister()
                    {
                        ClubSessionId = input.ClubSessionId,
                        RegisteredUserId = currentUserId,
                        TotalCosts = clubSession.Duration * clubSession.Club.CostPerHour
                    };

                    await Repository
                        .InsertAsync(entity);
                }
            }
            return true;
        }
    }
}