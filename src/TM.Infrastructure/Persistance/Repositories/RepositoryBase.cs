using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TM.Application.Common.Interfaces;

namespace TM.Infrastructure.Persistance.Repositories
{
    public abstract class RepositoryBase<TEntity>(TradeManagementDbContext context) : IRepositoryBase<TEntity> where TEntity : class
    {
        protected TradeManagementDbContext Context { get; private set; } = context;
        protected DbSet<TEntity> DbSet { get; private set; } = context.Set<TEntity>();

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<List<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await DbSet.Where(expression).ToListAsync();
        }

        public virtual async Task<TEntity?> FindByIdAsync(object id) => await DbSet.FindAsync(id);

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task DeleteAsync(object id)
        {
            var trade = await DbSet.FindAsync(id);
            DbSet.Attach(trade);
            DbSet.Remove(trade);
            await Context.SaveChangesAsync();
        }
    }
}