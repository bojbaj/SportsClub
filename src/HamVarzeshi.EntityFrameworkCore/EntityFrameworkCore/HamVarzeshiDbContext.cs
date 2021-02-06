using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using HamVarzeshi.Authorization.Roles;
using HamVarzeshi.Authorization.Users;
using HamVarzeshi.MultiTenancy;
using HamVarzeshi.Core.Domain;
using System.Reflection;

namespace HamVarzeshi.EntityFrameworkCore
{
    public class HamVarzeshiDbContext : AbpZeroDbContext<Tenant, Role, User, HamVarzeshiDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Club> Clubs { get; set; }
        public HamVarzeshiDbContext(DbContextOptions<HamVarzeshiDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
