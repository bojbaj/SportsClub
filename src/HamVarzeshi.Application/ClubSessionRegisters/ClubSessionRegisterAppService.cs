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
            return Repository.GetAllIncluding(x => x.ClubSession.Club)
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

        public async Task<ListResultDto<ClubSessionDto>> GetClubSessions()
        {
            var clubSessions = await _clubSessionRepository.GetAllListAsync();
            return new ListResultDto<ClubSessionDto>(ObjectMapper.Map<List<ClubSessionDto>>(clubSessions));
        }
    }
}