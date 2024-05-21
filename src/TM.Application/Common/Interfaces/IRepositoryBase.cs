﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TM.Application.Common.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> FindByIdAsync(object id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(object id);

    }
}