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
    public class AppServices : IAppRepository
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

        public AppServices()
        {
            _repository = new UnitOfWork<FIdentityContext>();
            _token = new TokenManager();
            _user = new UserManager();
        }

        #endregion

        public async Task<IEnumerable<Users>> GetAppUsersAsync(string appKey, int index, int count)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    if (await IsExistAppAsync(appKey))
                    {
                        IEnumerable<UserApps> joinApps = await _repository.UserAppsRepository.GetAllAsync(j => j.AppId == Guid.Parse(appKey));
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

        public async Task<bool> IsExistAppAsync(string appKey)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    return await _repository.AppsRepository.IsExistAsync(a => a.AppId == Guid.Parse(appKey));
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<ApplicationInfoViewModel> GetApplicationInfoAsync(string appKey, IHeaderDictionary header)
        {
            return await Task.Run(async () =>
            {
                ApplicationInfoViewModel response = new();

                try
                {
                    Users user = await _user.GetUserFromHeaders(header);
                    if (user != null)
                    {
                        if (await IsExistAppAsync(appKey))
                        {
                            Apps app = await _repository.AppsRepository.GetFirstOrDefaultAsync(a => a.AppId == Guid.Parse(appKey) && a.Owner == user.UserId);
                            if (app != null)
                            {
                                return new ApplicationInfoViewModel
                                {
                                    App = app,
                                    Status = ApplicationInfoStatus.Success,
                                    User = user,
                                    Features = (IList<AppFeatures>)await GetAppFeaturesAsync(appKey)
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
    }
}
