using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace HamVarzeshi.Web.Views
{
    public abstract class HamVarzeshiRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected HamVarzeshiRazorPage()
        {
            LocalizationSourceName = HamVarzeshiConsts.LocalizationSourceName;
        }
    }
}
