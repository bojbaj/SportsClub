using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using HamVarzeshi.Authorization;
using HamVarzeshi.Controllers;
using HamVarzeshi.Web.Models.Clubs;
using HamVarzeshi.Clubs;
using Abp.Application.Services.Dto;
using System;

namespace HamVarzeshi.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Clubs)]
    public class ClubsController : HamVarzeshiControllerBase
    {
        private readonly IClubAppService _clubAppService;

        public ClubsController(IClubAppService clubAppService)
        {
            _clubAppService = clubAppService;
        }

        public ActionResult Index()
        {
            var model = new ClubListViewModel();
            return View(model);
        }

        public async Task<ActionResult> EditModal(Guid clubId)
        {
            var club = await _clubAppService.GetAsync(new EntityDto<Guid>(clubId));
            var model = new EditClubModalViewModel
            {
                Club = club                
            };
            return PartialView("_EditModal", model);
        }
    }
}
