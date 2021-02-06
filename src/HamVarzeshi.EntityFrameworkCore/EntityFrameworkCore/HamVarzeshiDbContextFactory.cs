using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using HamVarzeshi.Configuration;
using HamVarzeshi.Web;

namespace HamVarzeshi.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class HamVarzeshiDbContextFactory : IDesignTimeDbContextFactory<HamVarzeshiDbContext>
    {
        public HamVarzeshiDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<HamVarzeshiDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            HamVarzeshiDbContextConfigurer.Configure(builder, configuration.GetConnectionString(HamVarzeshiConsts.ConnectionStringName));

            return new HamVarzeshiDbContext(builder.Options);
        }
    }
}
