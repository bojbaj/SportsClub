using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace HamVarzeshi.EntityFrameworkCore
{
    public static class HamVarzeshiDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<HamVarzeshiDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<HamVarzeshiDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
