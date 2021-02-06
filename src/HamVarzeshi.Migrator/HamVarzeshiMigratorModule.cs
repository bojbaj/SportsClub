using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using HamVarzeshi.Configuration;
using HamVarzeshi.EntityFrameworkCore;
using HamVarzeshi.Migrator.DependencyInjection;

namespace HamVarzeshi.Migrator
{
    [DependsOn(typeof(HamVarzeshiEntityFrameworkModule))]
    public class HamVarzeshiMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public HamVarzeshiMigratorModule(HamVarzeshiEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(HamVarzeshiMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                HamVarzeshiConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(HamVarzeshiMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
