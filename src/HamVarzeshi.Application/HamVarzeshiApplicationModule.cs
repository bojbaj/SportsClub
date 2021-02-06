using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using HamVarzeshi.Authorization;

namespace HamVarzeshi
{
    [DependsOn(
        typeof(HamVarzeshiCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class HamVarzeshiApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<HamVarzeshiAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(HamVarzeshiApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
