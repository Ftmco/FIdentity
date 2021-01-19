using Fri2Ends.Identity.Context;
using Fri2Ends.Identity.Services.Generic.UnitOfWork;
using Fri2Ends.Identity.Services.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Srevices
{
    /// <summary>
    /// Account Services 
    /// </summary>
    public class AccountManager : IAccountManager
    {
        #region --Dependency--

        /// <summary>
        /// Users Services
        /// </summary>
        private readonly IUserManager _user;

        /// <summary>
        /// Token Services
        /// </summary>
        private readonly ITokenManager _token;

        /// <summary>
        /// Unit Of Work Controlle Repository
        /// </summary>
        private readonly IUnitOfWork<FIdentityContext> _repository;

        /// <summary>
        /// Role Services
        /// </summary>
        private readonly IRoleManager _role;

        /// <summary>
        /// Selected Role Services
        /// </summary>
        private readonly ISelectedRoleManager _selectedRole;

        public AccountManager()
        {
            _selectedRole = new SelectedRoleManager();
            _role = new RoleManager();
            _token = new TokenManager();
            _user = new UserManager();
            _repository = new UnitOfWork<FIdentityContext>();
        }

        #endregion

        public async Task<ActivationResponse> ActiveUserAsync(ActivationViewModel activation)
        {
            ActivationResponse response = new();

            return await Task.Run(async () =>
            {
                var user = await _user.GetUserByEmailAsync(activation.Email);
                if (user != null)
                {
                    if (user.ActiveCode == activation.ActiveCode)
                    {
                        user.ActiveCode = Guid.NewGuid().GetHashCode().ToString().Replace("-", "").Substring(0, 6);
                        user.ActiveDate = DateTime.Now;
                        user.IsConfirm = true;
                        if (await _repository.UserRepository.UpdateAsync(user) && await _repository.SaveAsync())
                        {
                            Tokens token = await CreateTokenAsync(user, 20);

                            response.Success = new Success
                            {
                                IsSucces = true,
                                Key = token.TokenKey,
                                Value = token.TokenValue
                            };

                            await _repository.TokensRepository.InsertAsync(token); await _repository.SaveAsync();

                            response.Status = ActivationResponseEn.Success;
                            return response;
                        }
                        response.Status = ActivationResponseEn.Exception;
                        return response;
                    }
                    response.Status = ActivationResponseEn.WrongActiveCode;
                    return response;
                }
                response.Status = ActivationResponseEn.UserNotFound;
                return response;
            });
        }

        public async Task<bool> CheckPasswordAsync(Users user, string currentPassword)
        {
            return await Task.Run(async () =>
                 user.Password == await currentPassword.CreateSHA256Async());
        }

        public Task<DeleteAccountResponse> DeleteAccountAsync(DeleteAccountViewModel deleteAccount)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsInRoleAsync(string userName, string roleName)
        {
            return await Task.Run(async () =>
            {
                Users user = await _user.GetUserByUserNameAsync(userName);
                return await IsInRoleAsync(user, roleName);
            });
        }

        public async Task<bool> IsInRoleAsync(Users user, string roleName)
        {
            return await Task.Run(async () =>
            {
                Roles role = await _role.GetRoleByNameAsync(roleName);
                return await _selectedRole.IsExistAsync(user.UserId, role.RoleId);
            });
        }

        public async Task<bool> IsInRoleAsync(IRequestCookieCollection cookies, string roleName)
        {
            return await Task.Run(async () =>
            {
                Users user = await GetUserFromCookieAsync(cookies);
                return await IsInRoleAsync(user, roleName);
            });
        }

        public async Task<bool> IsInRoleAsync(IHeaderDictionary headers, string roleName)
        {
            return await Task.Run(async () =>
            {
                Users user = await GetUserFromHeaderAsync(headers);
                return await IsInRoleAsync(user, roleName);
            });
        }

        public async Task<LoginResponse> LoginAsync(LoginViewModel login, bool rememmeberMe, int expireDays = 20, HttpContext context = null)
        {
            return await Task.Run(async () =>
            {
                LoginResponse response = new();

                Users user = await _user.GetUserByEmailAsync(login.Email);
                if (user != null)
                {
                    if (await CheckPasswordAsync(user, login.Password))
                    {
                        Tokens token = await CreateTokenAsync(user, expireDays);
                        if (await _repository.TokensRepository.InsertAsync(token) && await _repository.SaveAsync())
                        {
                            LoginLogs log = await CreateLogAsync(token, context);
                            await _repository.LoginLogsRepository.InsertAsync(log); await _repository.SaveAsync();

                            //Create Success Type 
                            if (rememmeberMe)
                            {
                                response.Success = new Success
                                {
                                    IsSucces = true,
                                    Key = token.TokenKey,
                                    Value = token.TokenValue
                                };
                            }

                            response.Status = LoginStatus.Success;
                            return response;
                        }
                        response.Status = LoginStatus.Exception;
                        return response;
                    }
                    response.Status = LoginStatus.WrongPassword;
                    return response;
                }

                response.Status = LoginStatus.UserNotFound;
                return response;


            });
        }

        public async Task<bool> LogoutAsync(IRequestCookieCollection cookies)
        {
            return await Task.Run(async () =>
            {
                var token = cookies["Token"];
                return await _repository.TokensRepository.DeleteAsync(token) && await _repository.SaveAsync();
            });
        }

        public async Task<bool> LogoutAsync(IHeaderDictionary headers)
        {
            return await Task.Run(async () =>
            {
                var token = headers["Token"];
                return await _repository.TokensRepository.DeleteAsync(token) && await _repository.SaveAsync();
            });
        }

        public async Task<SignUpResponse> SignUpAsync(SignupViewModel signUp)
        {
            return await Task.Run(async () =>
            {
                var user = await _user.CreateUserAsync(signUp);
                if (!await _user.IsExistAsync(user.UserName))
                {
                    if (await _repository.UserRepository.InsertAsync(user) && await _repository.SaveAsync())
                    {
                        return SignUpResponse.Success;
                    }
                    return SignUpResponse.Exception;
                }
                return SignUpResponse.UserAlreadyExist;
            });
        }

        private async Task<Tokens> CreateTokenAsync(Users user, int expire)
        {
            return await Task.Run(() =>
            {
                return new Tokens
                {
                    UserId = user.UserId,
                    InsertDate = DateTime.Now,
                    ExpireDate = DateTime.Now.AddDays(expire),
                    TokenKey = "Token",
                    TokenValue = Guid.NewGuid().ToString().CreateSHA256()
                };
            });
        }

        private async Task<LoginLogs> CreateLogAsync(Tokens token, HttpContext context)
        {
            return await Task.Run(() =>
            {
                return new LoginLogs
                {
                    LocalIpAddress = context.Connection.LocalIpAddress.ToString(),
                    LocalPort = context.Connection.LocalPort.ToString(),
                    RemoteIpAddress = context.Connection.RemoteIpAddress.ToString(),
                    RemotePort = context.Connection.RemotePort.ToString(),
                    SetDate = DateTime.Now,
                    TokenId = token.TokenId
                };
            });
        }

        private async Task<Users> GetUserFromHeaderAsync(IHeaderDictionary header)
        {
            return await Task.Run(async () =>
            {
                Tokens token = await _token.GetTokenFromHeaderAsync(header);
                return (token != null) ? await _repository.UserRepository.FindByIdAsync(token.UserId) : null;
            });
        }

        private async Task<Users> GetUserFromCookieAsync(IRequestCookieCollection cookie)
        {
            return await Task.Run(async () =>
            {
                Tokens token = await _token.GetTokenFromCookiesAsync(cookie);
                return (token != null) ? await _repository.UserRepository.FindByIdAsync(token.UserId) : null;
            });
        }
    }
}
