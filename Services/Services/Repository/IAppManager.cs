using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services.Repository
{
    /// <summary>
    /// Application Repository
    /// </summary>
    public interface IAppManager
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
        Task<IEnumerable<Users>> GetAppUsersAsync(string appToken, int index, int count);

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

        /// <summary>
        /// Check Is Owner App
        /// </summary>
        /// <param name="appId">Application Id</param>
        /// <param name="header">Request Header</param>
        /// <returns>
        /// Is Owner True
        /// </returns>
        Task<bool> IsOwnerAsync(Guid appId, IHeaderDictionary header);

        /// <summary>
        /// Check Is Owner App
        /// </summary>
        /// <param name="appToken">Application Token</param>
        /// <param name="header">Request Header</param>
        /// <returns>
        /// Is Owner True
        /// </returns>
        Task<bool> IsOwnerAsync(string appToken, IHeaderDictionary header);
    }
}
