using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Generic
{
    public class GenericServices<TModel> : IGenericRepository<TModel> where TModel : class
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

        public GenericServices(DbContext db)
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

        public async Task<bool> DeleteAsync(IEnumerable<TModel> modelList)
        {
            return await Task.Run(() =>
            {
                try
                {
                    _dbSet.RemoveRange(modelList);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
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

        public async Task<TModel> GetFirstOrDefaultAsync(Expression<Func<TModel, bool>> firstOrDefault)
        {
            return await Task.Run(async () => await _dbSet.FirstOrDefaultAsync(firstOrDefault));
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

        public async Task<bool> InsertAsync(IEnumerable<TModel> modelList)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    await _dbSet.AddRangeAsync(modelList);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> IsExistAsync(Expression<Func<TModel, bool>> any)
        {
            return await Task.Run(async () => await _dbSet.AnyAsync(any));
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

        public async Task<bool> UpdateAsync(IEnumerable<TModel> modelList)
        {
            return await Task.Run(() =>
            {
                try
                {
                    _dbSet.UpdateRange(modelList);
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
