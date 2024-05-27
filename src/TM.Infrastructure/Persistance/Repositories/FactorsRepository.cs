using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TM.Domain.Entities;

namespace TM.Infrastructure.Persistance.Repositories
{
    public class FactorsRepository(TradeManagementDbContext context) : RepositoryBase<Factor>(context)
    {
        public override async Task<List<Factor>> GetAllAsync()
        {
            return await Context.
                Factors.Include(x => x.Setups).
                ToListAsync();
        }

        public override async Task<Factor?> FindByIdAsync(object id)
        {
            return await base.FindByIdAsync(id);
        }

        public override Task<List<Factor>> FindByConditionAsync(Expression<Func<Factor, bool>> expression)
        {
            return base.FindByConditionAsync(expression);
        }

        public override async Task<Factor> AddAsync(Factor entity)
        {
            return await base.AddAsync(entity);
        }

        public override async Task<Factor> UpdateAsync(Factor entity)
        {
            return await base.UpdateAsync(entity);
        }

        public override async Task<Factor> DeleteAsync(object id)
        {
            return await base.DeleteAsync(id);
        }
    }

}
