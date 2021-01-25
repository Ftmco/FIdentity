using Fri2Ends.Identity.Context;
using Fri2Ends.Identity.Services.Generic.UnitOfWork;
using Fri2Ends.Identity.Services.Repository;
using Fri2Ends.Identity.Services.Srevices;
using Microsoft.AspNetCore.Http;
using Services.Services.Repository;
using System;
using System.Collections.Generic;
using System.IO;
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

        public async Task<OwnerShipRequestStatus> OwnerRequestAsync(IRequestCookieCollection cookie, string coName, IFormFile coImage)
        {
            return await Task.Run(async () =>
            {
                Users user = await _user.GetUserFromCookiesAsync(cookie);
                return await OwnerRequestAsync(user.UserId, coName, coImage);
            });
        }

        public async Task<OwnerShipRequestStatus> OwnerRequestAsync(IHeaderDictionary header, string coName, IFormFile coImage)
        {
            return await Task.Run(async () =>
            {
                Users user = await _user.GetUserFromHeadersAsync(header);
                return await OwnerRequestAsync(user.UserId, coName, coImage);
            });
        }

        public async Task<OwnerShipRequestStatus> OwnerRequestAsync(Guid userId, string coName, IFormFile coImage)
        {
            return await Task.Run(async () =>
            {
                Users user = await _repository.UserRepository.FindByIdAsync(userId);
                if (user != null)
                {
                    var newOwner = await CreateOwnerAsync(userId, coName, coImage);
                    if (newOwner != null)
                    {
                        if (!await _repository.OwnerRepository.IsExistAsync(o => o.CompanyName == coName || o.UserId == userId))
                        {
                            if (await _repository.OwnerRepository.InsertAsync(newOwner) && await _repository.SaveAsync())
                            {
                                return OwnerShipRequestStatus.Success;
                            }
                            return OwnerShipRequestStatus.Exception;
                        }
                        return OwnerShipRequestStatus.CoExist;
                    }
                    return OwnerShipRequestStatus.Exception;
                }
                return OwnerShipRequestStatus.UserNotfound;
            });
        }

        public async Task<Owner> CreateOwnerAsync(Guid userId, string coName, IFormFile coImage)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    if (await ImageTool.CheckFormImageAsync(coImage))
                    {
                        string imageName = Guid.NewGuid().ToString() + Path.GetExtension(coImage.FileName);
                        string path = Directory.GetCurrentDirectory() + @"\Images\OwnerImages\";
                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);

                        using (var stream = new FileStream(path + imageName, FileMode.Create))
                        {
                            await coImage.CopyToAsync(stream);
                        }

                        return new Owner
                        {
                            CompanyName = coName,
                            ImageName = imageName,
                            OwnerToken = Guid.NewGuid().ToString().CreateSHA256(),
                            UserId = userId
                        };
                    }
                    return null;
                }
                catch
                {
                    return null;
                }
            });
        }
    }
}
