using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using HamVarzeshi.Authorization.Roles;
using HamVarzeshi.Authorization.Users;
using HamVarzeshi.MultiTenancy;

namespace HamVarzeshi.EntityFrameworkCore
{
    public class HamVarzeshiDbContext : AbpZeroDbContext<Tenant, Role, User, HamVarzeshiDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public HamVarzeshiDbContext(DbContextOptions<HamVarzeshiDbContext> options)
            : base(options)
        {
        }
    }
}
