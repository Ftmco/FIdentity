﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Generic
{
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {

        #region ::Dependency::

        /// <summary>
        /// Data Base Context
        /// </summary>
        private readonly DbContext _db;

        /// <summary>
        /// TModel Data Table
        /// </summary>
        private readonly DbSet<TModel> _dbSet;

        public GenericRepository(DbContext db)
        {
            _db = db;
            _dbSet = _db.Set<TModel>();
        }

        #endregion

        public async Task<bool> DeleteAsync(TModel model)
        {
            return await Task.Run(() =>
            {
                try
                {
                    _dbSet.Remove(model);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> DeleteAsync(object id)
        {
            return await Task.Run(async () => await DeleteAsync(await FindByIdAsync(id)));
        }

        public async Task<TModel> FindByIdAsync(object id)
        {
            return await Task.Run(async () => await _dbSet.FindAsync(id));
        }

        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            return await Task.Run(async () => await _dbSet.ToListAsync());
        }

        public async Task<IEnumerable<TModel>> GetAllAsync(Expression<Func<TModel, bool>> where)
        {
            return await Task.Run(async () => await _dbSet.Where(where).ToListAsync());
        }

        public async Task<bool> InsertAsync(TModel model)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    await _dbSet.AddAsync(model);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> UpdateAsync(TModel model)
        {
            return await Task.Run(() =>
            {
                try
                {
                    _dbSet.Update(model);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }
    }
}
