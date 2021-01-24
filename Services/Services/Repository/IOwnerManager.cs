using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Services.Services.Repository
{

    /// <summary>
    /// Owner Repository
    /// </summary>
    public interface IOwnerManager
    {
        /// <summary>
        /// Get Owner Info
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>OwnerInfoViewModel</returns>
        Task<OwnerInfoViewModel> GetOwnerInfoAsync(Guid userId);

        /// <summary>
        /// Get Owner Info from Headers
        /// </summary>
        /// <param name="header">Requst Header</param>
        /// <returns>OwnerInfoViewModel</returns>
        Task<OwnerInfoViewModel> GetOwnerInfoAsync(IHeaderDictionary header);

        /// <summary>
        /// Get Owner Info from Cookies
        /// </summary>
        /// <param name="cookie">Request Cookie</param>
        /// <returns>OwnerInfoViewModel</returns>
        Task<OwnerInfoViewModel> GetOwnerInfoAsync(IRequestCookieCollection cookie);
    }
}
