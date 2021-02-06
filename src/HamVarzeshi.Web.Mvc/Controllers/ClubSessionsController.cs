using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using HamVarzeshi.Authorization;
using HamVarzeshi.Controllers;
using HamVarzeshi.Web.Models.ClubSessions;
using HamVarzeshi.ClubSessions;
using Abp.Application.Services.Dto;
using System;
using HamVarzeshi.Clubs;
using HamVarzeshi.Clubs.Dto;

namespace HamVarzeshi.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Clubs)]
    public class ClubSessionsController : HamVarzeshiControllerBase
    {
        private readonly IClubAppService _clubAppService;
        private readonly IClubSessionAppService _clubSessionAppService;

        public ClubSessionsController(IClubSessionAppService clubSessionAppService, IClubAppService clubAppService)
        {
            _clubSessionAppService = clubSessionAppService;
            _clubAppService = clubAppService;
        }

        public async Task<ActionResult> Index()
        {
            PagedClubResultRequestDto requestDto = new PagedClubResultRequestDto()
            {
            };
            var clubs = (await _clubAppService.GetAllAsync(requestDto)).Items;

            var model = new ClubSessionListViewModel()
            {
                Clubs = clubs 
            };
            return View(model);
        }

        public async Task<ActionResult> EditModal(Guid clubSessionId)
        {
            PagedClubResultRequestDto requestDto = new PagedClubResultRequestDto()
            {
            };
            var clubs = (await _clubAppService.GetAllAsync(requestDto)).Items;
            var clubSession = await _clubSessionAppService.GetAsync(new EntityDto<Guid>(clubSessionId));
            var model = new EditClubSessionModalViewModel
            {
                ClubSession = clubSession,
                Clubs = clubs
            };
            return PartialView("_EditModal", model);
        }
    }
}
