using System.Linq.Expressions;
using TM.Domain.Entities;

namespace TM.Infrastructure.Persistance.Repositories
{
    public class TradesRepository(TradeManagementDbContext context) : RepositoryBase<Trade>(context)
    {
        public override async Task<List<Trade>> GetAllAsync()
        {
            return await base.GetAllAsync();
        }

        public override Task<Trade?> FindByIdAsync(object id)
        {
            return base.FindByIdAsync(id);
        }

        public override Task<List<Trade>> FindByConditionAsync(Expression<Func<Trade, bool>> expression)
        {
            return base.FindByConditionAsync(expression);
        }

        public override async Task AddAsync(Trade entity)
        {
            await base.AddAsync(entity);
        }

        public override Task UpdateAsync(Trade entity)
        {
            return base.UpdateAsync(entity);
        }

        public override Task DeleteAsync(Trade entity)
        {
            return base.DeleteAsync(entity);
        }
    }
}
