using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TM.Domain.Entities;

namespace TM.Infrastructure.Persistance.Repositories
{
    public class SetupsRepository(TradeManagementDbContext context) : RepositoryBase<Setup>(context)
    {
        public override async Task<List<Setup>> GetAllAsync()
        {
            return await Context.
                Setups.Include(x => x.Trades)
                .Include(x => x.Factors)
                .ToListAsync();
        }

        public override async Task<Setup?> FindByIdAsync(object id)
        {
            var res =  await Context.Setups
              .Include(i => i.Factors)
              .FirstOrDefaultAsync(x => x.ID == id.ToString());
            return res;
        }

        public override async Task<List<Setup>> FindByConditionAsync(Expression<Func<Setup, bool>> expression)
        {
            return await base.FindByConditionAsync(expression);
        }

        public override async Task<Setup> AddAsync(Setup entity)
        {
            return await base.AddAsync(entity);
        }

        public override async Task<Setup> UpdateAsync(Setup entity)
        {
            return await base.UpdateAsync(entity);
        }

        public override async Task<Setup> DeleteAsync(object id)
        {
            return await base.DeleteAsync(id);
        }
    }

}
