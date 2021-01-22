using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Repository
{
    public interface IAppRepository
    {
        Task<IEnumerable<Users>> GetAppUsersAsync(string appKey, int index, int count);
        Task<bool> IsExistAppAsync(string appKey);
        Task<ApplicationInfoViewModel> GetApplicationInfoAsync(string appKey,IHeaderDictionary header);
        Task<IEnumerable<AppFeatures>> GetAppFeaturesAsync(string appKey);
    }
}
