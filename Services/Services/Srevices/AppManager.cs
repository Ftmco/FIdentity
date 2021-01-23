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

        public AppManager()
        {
            _repository = new UnitOfWork<FIdentityContext>();
            _token = new TokenManager();
            _user = new UserManager();
        }

        #endregion

        public async Task<IEnumerable<Users>> GetAppUsersAsync(string appToken, int index, int count)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    if (await IsExistAppAsync(appToken))
                    {
                        IEnumerable<UserApps> joinApps = await _repository.UserAppsRepository.GetAllAsync(j => j.AppToken == appToken);
                        IList<Users> users = (IList<Users>)await _user.GetUsersFromUsersAppsAsync(joinApps);
                        if (users.Any())
                        {
                            return users.Skip(index * count).Take(count);
                        }
                        return null;
                    }
                    return null;
                }
                catch
                {
                    return null;
                }
            });
        }

        public async Task<bool> IsExistAppAsync(string appToken)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    return await _repository.AppsRepository.IsExistAsync(a => a.AppToken == appToken);
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<ApplicationInfoViewModel> GetApplicationInfoAsync(string appToken, IHeaderDictionary header)
        {
            return await Task.Run(async () =>
            {
                ApplicationInfoViewModel response = new();

                try
                {
                    Users user = await _user.GetUserFromHeaders(header);
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
                try
                {
                    string ownerToken = header["Owner"].ToString();
                    Owner owner = await _repository.OwnerRepository.GetFirstOrDefaultAsync(o => o.OwnerToken == ownerToken);
                    Apps app = await _repository.AppsRepository.FindByIdAsync(appId);
                    return app.OwnerId == owner.OwnerId;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> IsOwnerAsync(string appToken, IHeaderDictionary header)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    string ownerToken = header["Owner"].ToString();
                    Owner owner = await _repository.OwnerRepository.GetFirstOrDefaultAsync(o => o.OwnerToken == ownerToken);
                    Apps app = await _repository.AppsRepository.GetFirstOrDefaultAsync(a => a.AppToken == appToken);
                    return app.OwnerId == owner.OwnerId;
                }
                catch
                {
                    return false;
                }
            });
        }

        public  Task<IEnumerable<Apps>> GetOwnerAppsAsync(IHeaderDictionary header)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Apps>> GetOwnerAppsAsync(IRequestCookieCollection cookie)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Apps>> GetOwnerAppsAsync(Guid ownerId)
        {
            throw new NotImplementedException();
        }
    }
}
