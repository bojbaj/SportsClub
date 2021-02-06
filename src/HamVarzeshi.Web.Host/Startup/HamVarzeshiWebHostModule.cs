using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using HamVarzeshi.Configuration;

namespace HamVarzeshi.Web.Host.Startup
{
    [DependsOn(
       typeof(HamVarzeshiWebCoreModule))]
    public class HamVarzeshiWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public HamVarzeshiWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(HamVarzeshiWebHostModule).GetAssembly());
        }
    }
}
