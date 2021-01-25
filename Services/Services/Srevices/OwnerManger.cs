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
    public class OwnerManger : IOwnerManager
    {
        #region __Depdency__

        private IUnitOfWork<FIdentityContext> _repository;

        private IUserManager _user;

        public OwnerManger()
        {
            _repository = new UnitOfWork<FIdentityContext>();
            _user = new UserManager();
        }

        #endregion

        public async Task<OwnerInfoViewModel> GetOwnerInfoAsync(Guid userId)
        {
            return await Task.Run(async () =>
            {
                Users user = await _repository.UserRepository.FindByIdAsync(userId);
                if (user != null)
                {
                    Owner owner = await _repository.OwnerRepository.GetFirstOrDefaultAsync(o => o.UserId == user.UserId);
                    if (owner != null)
                    {
                        IEnumerable<Apps> apps = await _repository.AppsRepository.GetAllAsync(a => a.OwnerId == owner.OwnerId);
                        return new OwnerInfoViewModel
                        {
                            OwnerId = owner.OwnerId,
                            Email = user.Email,
                            UserName = user.UserName,
                            AppCount = apps.Count(),
                            UserProfileImageName = user.UserProfileImageName,
                            Token = owner.OwnerToken
                        };
                    }
                    return null;
                }
                return null;
            });
        }

        public async Task<OwnerInfoViewModel> GetOwnerInfoAsync(IHeaderDictionary header)
        {
            return await Task.Run(async () =>
            {
                Users user = await _user.GetUserFromHeadersAsync(header);
                if (user != null)
                {
                    return await GetOwnerInfoAsync(user.UserId);
                }
                return null;
            });
        }

        public async Task<OwnerInfoViewModel> GetOwnerInfoAsync(IRequestCookieCollection cookie)
        {
            return await Task.Run(async () =>
            {
                Users user = await _user.GetUserFromCookiesAsync(cookie);
                if (user != null)
                {
                    return await GetOwnerInfoAsync(user.UserId);
                }
                return null;
            });
        }
    }
}
