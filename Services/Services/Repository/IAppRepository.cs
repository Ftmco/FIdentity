using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services.Repository
{
    /// <summary>
    /// Application Repository
    /// </summary>
    public interface IAppRepository
    {
        /// <summary>
        /// Get Application Users
        /// </summary>
        /// <param name="appKey">Application Id</param>
        /// <param name="index">Index</param>
        /// <param name="count">Show Count</param>
        /// <returns>
        /// Users List(IEnumerable)
        /// </returns>
        Task<IEnumerable<Users>> GetAppUsersAsync(string appKey, int index, int count);

        /// <summary>
        /// Check Exist App 
        /// </summary>
        /// <param name="appKey">App Id</param>
        /// <returns>
        /// Exist = True
        /// </returns>
        Task<bool> IsExistAppAsync(string appKey);

        /// <summary>
        /// Get Application Information
        /// </summary>
        /// <param name="appKey">App Id</param>
        /// <param name="header">Header Request</param>
        /// <returns>ApplicationInfoViewModel</returns>
        Task<ApplicationInfoViewModel> GetApplicationInfoAsync(string appKey, IHeaderDictionary header);

        /// <summary>
        /// Get App Features
        /// </summary>
        /// <param name="appKey">App Id</param>
        /// <returns>
        /// List Features (IEnumerable)
        /// </returns>
        Task<IEnumerable<AppFeatures>> GetAppFeaturesAsync(string appKey);
    }
}
