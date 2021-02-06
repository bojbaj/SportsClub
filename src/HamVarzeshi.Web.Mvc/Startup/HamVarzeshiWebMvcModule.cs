using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using HamVarzeshi.Configuration;

namespace HamVarzeshi.Web.Startup
{
    [DependsOn(typeof(HamVarzeshiWebCoreModule))]
    public class HamVarzeshiWebMvcModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public HamVarzeshiWebMvcModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<HamVarzeshiNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(HamVarzeshiWebMvcModule).GetAssembly());
        }
    }
}
