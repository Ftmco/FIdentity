using Fri2Ends.Identity.Context;
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
        private readonly FIdentityContext _db;

        public GenericRepository(FIdentityContext db)
        {
            _db = db;
        }

        #endregion

        public Task<bool> DeleteAsync(TModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<TModel> FindByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TModel>> GetAllAsync(Expression<Func<TModel, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(TModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(TModel model)
        {
            throw new NotImplementedException();
        }
    }
}
