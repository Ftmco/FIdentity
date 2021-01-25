using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Repository
{
    public interface IUserManager
    {
        Task<IEnumerable<Users>> GetUsersBySearchAsync(string q);
        Task<Users> GetUserByUserNameAsync(string userName);
        Task<Users> GetUserByEmailAsync(string email);
        Task<Users> GetUserFromCookiesAsync(IRequestCookieCollection cookies);
        Task<Users> GetUserFromHeadersAsync(IHeaderDictionary headers);
        Task<bool> IsExistAsync(Guid userId);
        Task<bool> IsExistAsync(string userName);
        Task<bool> IsExistAsync(Users user);
        Task<bool> IsExistPhoneAsync(string phone);
        Task<Users> CreateUserAsync(SignupViewModel signp);
        Task<IEnumerable<Users>> GetUsersFromUsersAppsAsync(IEnumerable<UserApps> usersApp);
    }
}
