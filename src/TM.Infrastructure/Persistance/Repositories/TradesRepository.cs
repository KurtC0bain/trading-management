using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TM.Application.Common.Models;
using TM.Domain.Entities;

namespace TM.Infrastructure.Persistance.Repositories
{
    public class TradesRepository(TradeManagementDbContext context) : RepositoryBase<Trade>(context)
    {
        public override async Task<List<Trade>> GetAllAsync()
        {
            return await Context.
                Trades.
                Include(s => s.Setup).
                Include(p => p.Pair).
                ToListAsync();
        }

        public override Task<Trade?> FindByIdAsync(object id)
        {
            return base.FindByIdAsync(id);
        }

        public override Task<List<Trade>> FindByConditionAsync(Expression<Func<Trade, bool>> expression)
        {
            return base.FindByConditionAsync(expression);
        }

        public override async Task<Trade> AddAsync(Trade entity)
        {
            return await base.AddAsync(entity);
        }

        public override async Task<Trade> UpdateAsync(Trade entity)
        {
            return await base.UpdateAsync(entity);
        }

        public override async Task<Trade> DeleteAsync(object id)
        {
            return await base.DeleteAsync(id);
        }
    }
}
