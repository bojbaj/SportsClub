using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using HamVarzeshi.Authorization;
using HamVarzeshi.Controllers;
using HamVarzeshi.Web.Models.ClubSessionRegisters;
using HamVarzeshi.ClubSessionRegisters;
using Abp.Application.Services.Dto;
using System;
using HamVarzeshi.Clubs;
using HamVarzeshi.Clubs.Dto;
using HamVarzeshi.ClubSessions;
using HamVarzeshi.ClubSessions.Dto;
using HamVarzeshi.ClubSessionRegisters.Dto;
using Abp.Runtime.Security;

namespace HamVarzeshi.Web.Controllers
{
    [AbpMvcAuthorize]
    public class ClubSessionRegistersController : HamVarzeshiControllerBase
    {
        private readonly IClubSessionRegisterAppService _clubSessionRegisterAppService;

        public ClubSessionRegistersController(IClubSessionRegisterAppService clubSessionRegisterAppService)
        {
            _clubSessionRegisterAppService = clubSessionRegisterAppService;
        }

        public async Task<ActionResult> Index()
        {
            var clubs = (await _clubSessionRegisterAppService.GetClubs()).Items;

            var clubSessionResultRequestDto = new PagedClubSessionResultRequestDto();
            var clubSessions = (await _clubSessionRegisterAppService.GetClubSessions(clubSessionResultRequestDto)).Items;

            var clubSessionRegisterResultRequestDto = new PagedClubSessionRegisterResultRequestDto()
            {
                UserId = Convert.ToInt64(User.Identity.GetUserId())
            };
            var clubSessionRegisters = (await _clubSessionRegisterAppService.GetAllAsync(clubSessionRegisterResultRequestDto)).Items;

            var model = new ClubSessionRegisterListViewModel()
            {
                Clubs = clubs,
                ClubSessions = clubSessions
            };
            return View(model);
        }
    }
}
