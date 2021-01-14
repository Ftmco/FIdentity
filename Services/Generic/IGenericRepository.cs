using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Generic
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<IEnumerable<TModel>> GetAllAsync(Expression<Func<TModel,bool>> where);
        Task<TModel> FindByIdAsync(object id);
        Task<bool> InsertAsync(TModel model);
        Task<bool> UpdateAsync(TModel model);
        Task<bool> DeleteAsync(TModel model);
        Task<bool> DeleteAsync(object id);
    }
}
