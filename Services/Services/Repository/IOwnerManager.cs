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

        /// <summary>
        /// Ownership Request 
        /// </summary>
        /// <param name="cookie">Request Cookies</param>
        /// <param name="coName">Company Name</param>
        /// <param name="coImage">Company Image</param>
        /// <returns>OwnerShipRequestStatus</returns>
        Task<OwnerShipRequestStatus> OwnerRequestAsync(IRequestCookieCollection cookie, string coName, IFormFile coImage);

        /// <summary>
        /// Ownership Request 
        /// </summary>
        /// <param name="header">Request Headers</param>
        /// <param name="coName">Company Name</param>
        /// <param name="coImage">Company Image</param>
        /// <returns>OwnerShipRequestStatus</returns>
        Task<OwnerShipRequestStatus> OwnerRequestAsync(IHeaderDictionary header, string coName, IFormFile coImage);

        /// <summary>
        /// Ownership Request
        /// </summary>
        /// <param name="userId">Current User Id</param>
        /// <param name="coName">Company Name</param>
        /// <param name="coImage">Company Image</param>
        /// <returns>OwnerShipRequestStatus</returns>
        Task<OwnerShipRequestStatus> OwnerRequestAsync(Guid userId, string coName, IFormFile coImage);

        /// <summary>
        /// Create Owner Model
        /// </summary>
        /// <param name="userId">Current User Id</param>
        /// <param name="coName">Company Name</param>
        /// <param name="coImage">Company Image</param>
        /// <returns>Owner Model</returns>
        Task<Owner> CreateOwnerAsync(Guid userId, string coName, IFormFile coImage);

    }
}
