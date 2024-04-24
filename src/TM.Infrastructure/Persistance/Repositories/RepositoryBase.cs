using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TM.Application.Common.Interfaces;

namespace TM.Infrastructure.Persistance.Repositories
{
    public abstract class RepositoryBase<TEntity>(DbContext context) : IRepositoryBase<TEntity> where TEntity : class
    {
        protected DbContext Context { get; private set; } = context;
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

        public virtual async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            DbSet.Remove(entity);
            await Context.SaveChangesAsync();
        }
    }
}