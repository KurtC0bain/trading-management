using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TM.Domain.Entities;

namespace TM.Infrastructure.Persistance
{
    public class TradeManagementDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Trade> Trades { get; set; }
        public DbSet<Pair> Pairs { get; set; }
        public DbSet<Setup> Setups { get; set; }
        public DbSet<Factor> Factors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
