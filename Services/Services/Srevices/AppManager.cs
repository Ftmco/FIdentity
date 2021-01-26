using Fri2Ends.Identity.Context;
using Fri2Ends.Identity.Services.Generic.UnitOfWork;
using Fri2Ends.Identity.Services.Repository;
using Fri2Ends.Identity.Services.Srevices;
using Microsoft.AspNetCore.Http;
using Services.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services.Srevices
{
    public class AppManager : IAppManager
    {
        #region __Dependency__

        /// <summary>
        /// Repository Services
        /// </summary>
        private readonly IUnitOfWork<FIdentityContext> _repository;

        /// <summary>
        /// Token Services
        /// </summary>
        private readonly ITokenManager _token;

        /// <summary>
        /// Users Services 
        /// </summary>
        private readonly IUserManager _user;

        /// <summary>
        /// Owner Services
        /// </summary>
        private readonly IOwnerManager _owner;

        public AppManager()
        {
            _repository = new UnitOfWork<FIdentityContext>();
            _token = new TokenManager();
            _user = new UserManager();
            _owner = new OwnerManger();
        }

        #endregion

        public async Task<IEnumerable<Users>> GetAppUsersAsync(string appToken, int index, int count)
        {
            return await Task.Run(async () =>
            {
                if (await IsExistAppAsync(appToken))
                {
                    IEnumerable<UserApps> joinApps = await _repository.UserAppsRepository.GetAllAsync(j => j.AppToken == appToken);
                    IList<Users> users = (IList<Users>)await _user.GetUsersFromUsersAppsAsync(joinApps);

                    return (users.Any()) ?
                    users.Skip(index * count).Take(count) : null;
                }
                return null;
            });
        }

        public async Task<bool> IsExistAppAsync(string appToken)
        {
            return await Task.Run(async () =>
            {
                return await _repository.AppsRepository.IsExistAsync(a => a.AppToken == appToken);
            });
        }

        public async Task<ApplicationInfoViewModel> GetApplicationInfoAsync(string appToken, IHeaderDictionary header)
        {
            return await Task.Run(async () =>
            {
                ApplicationInfoViewModel response = new();

                try
                {
                    Users user = await _user.GetUserFromHeadersAsync(header);
                    if (user != null)
                    {
                        if (await IsExistAppAsync(appToken))
                        {
                            if (await IsOwnerAsync(appToken, header))
                            {
                                return new ApplicationInfoViewModel
                                {
                                    App = await _repository.AppsRepository.GetFirstOrDefaultAsync(a => a.AppToken == appToken),
                                    Status = ApplicationInfoStatus.Success,
                                    User = user,
                                    Features = (IList<AppFeatures>)await GetAppFeaturesAsync(appToken)
                                };
                            }
                            response.Status = ApplicationInfoStatus.AppNotfound;
                            return response;
                        }
                        response.Status = ApplicationInfoStatus.AppNotfound;
                        return response;
                    }
                    response.Status = ApplicationInfoStatus.AppNotfound;
                    return response;
                }
                catch
                {
                    response.Status = ApplicationInfoStatus.Exception;
                    return response;
                }
            });
        }

        public async Task<IEnumerable<AppFeatures>> GetAppFeaturesAsync(string appKey)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    IEnumerable<AppSelectedFeatures> selectedFeatures = await _repository.AppSelectedFeaturesRepository.GetAllAsync(f => f.AppId == Guid.Parse(appKey));
                    IList<AppFeatures> features = new List<AppFeatures>();

                    foreach (var item in selectedFeatures)
                    {
                        features.Add(await _repository.AppFeaturesRepository.FindByIdAsync(item.FeatureId));
                    }
                    return features;
                }
                catch
                {
                    return null;
                }
            });
        }

        public async Task<bool> IsOwnerAsync(Guid appId, IHeaderDictionary header)
        {
            return await Task.Run(async () =>
            {
                string ownerToken = header["Owner"].ToString();
                Owner owner = await _repository.OwnerRepository.GetFirstOrDefaultAsync(o => o.OwnerToken == ownerToken);
                Apps app = await _repository.AppsRepository.FindByIdAsync(appId);
                return app.OwnerId == owner.OwnerId;
            });
        }

        public async Task<bool> IsOwnerAsync(string appToken, IHeaderDictionary header)
        {
            return await Task.Run(async () =>
            {
                string ownerToken = header["Owner"].ToString();
                Owner owner = await _repository.OwnerRepository.GetFirstOrDefaultAsync(o => o.OwnerToken == ownerToken);
                Apps app = await _repository.AppsRepository.GetFirstOrDefaultAsync(a => a.AppToken == appToken);
                return app.OwnerId == owner.OwnerId;
            });
        }

        public async Task<IEnumerable<Apps>> GetOwnerAppsAsync(IHeaderDictionary header)
        {
            return await Task.Run(async () =>
            {
                Users user = await _user.GetUserFromHeadersAsync(header);
                if (user != null)
                {
                    Owner owner = await _repository.OwnerRepository.GetFirstOrDefaultAsync(o => o.UserId == user.UserId);
                    return (owner != null) ?
                    await GetOwnerAppsAsync(owner.OwnerId) :
                   null;
                }
                return null;
            });
        }

        public async Task<IEnumerable<Apps>> GetOwnerAppsAsync(IRequestCookieCollection cookie)
        {
            return await Task.Run(async () =>
            {
                Users user = await _user.GetUserFromCookiesAsync(cookie);
                if (user != null)
                {
                    Owner owner = await _repository.OwnerRepository.GetFirstOrDefaultAsync(o => o.UserId == user.UserId);
                    return (owner != null) ?
                   await GetOwnerAppsAsync(owner.OwnerId) :
                   null;
                }
                return null;
            });
        }

        public async Task<IEnumerable<Apps>> GetOwnerAppsAsync(Guid ownerId)
        {
            return await Task.Run(async () => await _repository.AppsRepository.GetAllAsync(a => a.OwnerId == ownerId));
        }

        public async Task<CreateAppResponse> CreateAppAsync(string appTitle, IHeaderDictionary header)
        {
            return await Task.Run(async () => await CreateAppAsync(appTitle, await _user.GetUserFromHeadersAsync(header)));
        }

        public async Task<CreateAppResponse> CreateAppAsync(string appTitle, IRequestCookieCollection cookie)
        {
            return await Task.Run(async () => await CreateAppAsync(appTitle, await _user.GetUserFromCookiesAsync(cookie)));
        }

        public async Task<CreateAppResponse> CreateAppAsync(string appTitle, Users user)
        {
            return await Task.Run(async () =>
            {
                if (user != null)
                {
                    OwnerInfoViewModel owner = await _owner.GetOwnerInfoAsync(user.UserId);
                    if (owner != null)
                    {
                        var result = await _repository.AppsRepository.InsertAsync(new Apps
                        {
                            AppTitle = appTitle,
                            AppToken = Guid.NewGuid().ToString().CreateSHA256(),
                            IsActive = true,
                            CreateDate = DateTime.Now,
                            OwnerId = owner.OwnerId,
                            TokenType = (int)AppTokenType.Global
                        }) && await _repository.SaveAsync();

                        return result ? CreateAppResponse.Success : CreateAppResponse.Exception;
                    }
                    return CreateAppResponse.OwnerNotFound;
                }
                return CreateAppResponse.OwnerNotFound;
            });
        }

        public async Task<DeleteAppStatus> DeleteAppAsync(IRequestCookieCollection cookie, Guid appId)
        {
            return await Task.Run(async () =>
            {
                Users user = await _user.GetUserFromCookiesAsync(cookie);
                return await DeleteAppAsync(user.UserId, appId);
            });
        }

        public async Task<DeleteAppStatus> DeleteAppAsync(IHeaderDictionary header, Guid appId)
        {
            return await Task.Run(async () =>
            {
                Users user = await _user.GetUserFromHeadersAsync(header);
                return await DeleteAppAsync(user.UserId, appId);
            });
        }

        public async Task<DeleteAppStatus> DeleteAppAsync(Guid userId, Guid appId)
        {
            return await Task.Run(async () =>
            {
                OwnerInfoViewModel owner = await _owner.GetOwnerInfoAsync(userId);
                if (owner != null)
                {
                    IEnumerable<Apps> apps = await GetOwnerAppsAsync(owner.OwnerId);
                    if (apps.Any())
                    {
                        Apps app = apps.FirstOrDefault(a => a.AppId == appId);
                        if (app != null)
                        {
                            return (await _repository.AppsRepository.DeleteAsync(app) && await _repository.SaveAsync()) ?
                            DeleteAppStatus.Success :
                           DeleteAppStatus.Exception;
                        }
                        return DeleteAppStatus.AppNotFound;
                    }
                    return DeleteAppStatus.AppNotFound;
                }
                return DeleteAppStatus.AccessDenied;
            });
        }

        public async Task<IEnumerable<ApplicationUsersViewModel>> GetAppUsersViewModelAsync(string appToken, int index, int count)
        {
            return await Task.Run(async () =>
            {
                IEnumerable<Users> result = await GetAppUsersAsync(appToken, index, count);
                return result.Select(au => new ApplicationUsersViewModel
                {
                    ActiveDate = au.ActiveDate,
                    Email = au.Email,
                    IsActive = au.IsConfirm,
                    PhoneNumber = au.PhoneNumber,
                    ProfileImageName = au.UserProfileImageName,
                    UserId = au.UserId,
                    UserName = au.UserName
                }).ToList();
            });
        }
    }
}
