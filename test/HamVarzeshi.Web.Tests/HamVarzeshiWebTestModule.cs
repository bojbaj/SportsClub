using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using HamVarzeshi.EntityFrameworkCore;
using HamVarzeshi.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace HamVarzeshi.Web.Tests
{
    [DependsOn(
        typeof(HamVarzeshiWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class HamVarzeshiWebTestModule : AbpModule
    {
        public HamVarzeshiWebTestModule(HamVarzeshiEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(HamVarzeshiWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(HamVarzeshiWebMvcModule).Assembly);
        }
    }
}