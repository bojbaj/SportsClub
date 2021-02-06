using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace HamVarzeshi.Controllers
{
    public abstract class HamVarzeshiControllerBase: AbpController
    {
        protected HamVarzeshiControllerBase()
        {
            LocalizationSourceName = HamVarzeshiConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
