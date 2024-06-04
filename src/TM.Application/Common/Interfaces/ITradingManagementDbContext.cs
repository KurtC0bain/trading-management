using Microsoft.EntityFrameworkCore;
using TM.Domain.Entities;

namespace TM.Application.Common.Interfaces
{
    public interface ITradingManagementDbContext
    {
        public DbSet<Trade> Trades { get; set; }
        public DbSet<Pair> Pairs { get; set; }
        public DbSet<Setup> Setups { get; set; }
        public DbSet<Factor> Factors { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
