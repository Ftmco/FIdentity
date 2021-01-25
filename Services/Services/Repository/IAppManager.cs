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
        /// Find and Return Owner Apps
        /// </summary>
        /// <param name="header">Request Header</param>
        /// <returns>
        /// List Apps
        /// </returns>
        Task<IEnumerable<Apps>> GetOwnerAppsAsync(IHeaderDictionary header);

        /// <summary>
        ///  Find and Return Owner Apps
        /// </summary>
        /// <param name="cookie">Request Cookies</param>
        /// <returns>
        /// List Apps
        /// </returns>
        Task<IEnumerable<Apps>> GetOwnerAppsAsync(IRequestCookieCollection cookie);

        /// <summary>
        ///  Find and Return Owner Apps
        /// </summary>
        /// <param name="ownerId">Owner Id</param>
        /// <returns>
        /// List Apps
        /// </returns>
        Task<IEnumerable<Apps>> GetOwnerAppsAsync(Guid ownerId);

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

        /// <summary>
        /// Create New Appliction
        /// </summary>
        /// <param name="appTitle">Application Title</param>
        /// <param name="header">Request Headers</param>
        /// <returns></returns>
        Task<CreateAppResponse> CreateAppAsync(string appTitle,IHeaderDictionary header);

        /// <summary>
        /// Create New Appliction
        /// </summary>
        /// <param name="appTitle">Application Title</param>
        /// <param name="cookie">Request Cookies</param>
        /// <returns></returns>
        Task<CreateAppResponse> CreateAppAsync(string appTitle,IRequestCookieCollection cookie);

        /// <summary>
        /// Create New Appliction
        /// </summary>
        /// <param name="appTitle">Application Title</param>
        /// <param name="user">Users</param>
        /// <returns></returns>
        Task<CreateAppResponse> CreateAppAsync(string appTitle, Users user);

        /// <summary>
        /// Delete Application
        /// </summary>
        /// <param name="cookie">Request Cookie</param>
        /// <param name="appId">Application Id</param>
        /// <returns>DeleteAppStatus</returns>
        Task<DeleteAppStatus> DeleteAppAsync(IRequestCookieCollection cookie, Guid appId);

        /// <summary>
        /// Delete Application
        /// </summary>
        /// <param name="header">Request Headers</param>
        /// <param name="appId">Application Id</param>
        /// <returns>DeleteAppStatus</returns>
        Task<DeleteAppStatus> DeleteAppAsync(IHeaderDictionary header, Guid appId);

        /// <summary>
        /// Delete Application
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="appId">Application Id</param>
        /// <returns>DeleteAppStatus</returns>
        Task<DeleteAppStatus> DeleteAppAsync(Guid userId, Guid appId);
    }
}
