using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TM.Domain.Entities;

namespace TM.Infrastructure.Persistance.Repositories
{
    public class PairsRepository(TradeManagementDbContext context) : RepositoryBase<Pair>(context)
    {
        public override async Task<List<Pair>> GetAllAsync()
        {
            return await Context.
                Pairs.Include(x => x.Trades).
                ToListAsync();
        }

        public override async Task<Pair?> FindByIdAsync(object id)
        {
            return await base.FindByIdAsync(id);
        }

        public override async Task<List<Pair>> FindByConditionAsync(Expression<Func<Pair, bool>> expression)
        {
            return await base.FindByConditionAsync(expression);
        }

        public override async Task<Pair> AddAsync(Pair entity)
        {
            return await base.AddAsync(entity);
        }

        public override async Task<Pair> UpdateAsync(Pair entity)
        {
            return await base.UpdateAsync(entity);
        }

        public override async Task<Pair> DeleteAsync(object id)
        {
            return await base.DeleteAsync(id);
        }
    }

}
