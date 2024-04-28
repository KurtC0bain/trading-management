using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TM.Application.Common.Interfaces;
using TM.Domain.Entities;
using TM.Infrastructure.Persistance.Extensrions;

namespace TM.Infrastructure.Persistance
{
    public class TradeManagementDbContext(DbContextOptions options) : DbContext(options), ITradingManagementDbContext
    {
        public DbSet<Trade> Trades { get; set; }
        public DbSet<Pair> Pairs { get; set; }
        public DbSet<Setup> Setups { get; set; }
        public DbSet<Factor> Factors { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Seed();
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
