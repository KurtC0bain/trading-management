using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Emit;
using TM.Application.Common.Interfaces;
using TM.Domain.Entities;
using TM.Infrastructure.Persistance.Extensrions;

namespace TM.Infrastructure.Persistance
{
    public class TradeManagementDbContext(DbContextOptions<TradeManagementDbContext> options) : IdentityDbContext<IdentityUser>(options), ITradingManagementDbContext
    {
        public DbSet<Trade> Trades { get; set; }
        public DbSet<Pair> Pairs { get; set; }
        public DbSet<Setup> Setups { get; set; }
        public DbSet<Factor> Factors { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Seed();
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        
        }
    }
}
