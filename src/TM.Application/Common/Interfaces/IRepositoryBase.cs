﻿using System.Linq.Expressions;

namespace TM.Application.Common.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> FindByIdAsync(object id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(object id);

    }
}
