using Abp.AspNetCore.Mvc.ViewComponents;

namespace HamVarzeshi.Web.Views
{
    public abstract class HamVarzeshiViewComponent : AbpViewComponent
    {
        protected HamVarzeshiViewComponent()
        {
            LocalizationSourceName = HamVarzeshiConsts.LocalizationSourceName;
        }
    }
}
