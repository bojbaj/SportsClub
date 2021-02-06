using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using HamVarzeshi.Controllers;

namespace HamVarzeshi.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : HamVarzeshiControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
