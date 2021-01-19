using Fri2Ends.Identity.Context;
using Fri2Ends.Identity.Services.Generic.UnitOfWork;
using Fri2Ends.Identity.Services.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Srevices
{
    public class UserManager : IUserManager
    {
        #region ::Dependency::


        /// <summary>
        /// Unit Of Work Repository
        /// </summary>
        private readonly IUnitOfWork<FIdentityContext> _repository;

        public UserManager()
        {
            _repository = new UnitOfWork<FIdentityContext>();
        }

        #endregion

        public async Task<Users> CreateUserAsync(SignupViewModel signp)
        {
            return await Task.Run(() =>
            {
                return new Users()
                {
                    ActiveCode = Guid.NewGuid().GetHashCode().ToString().Replace("-", "").Substring(0, 6),
                    ActiveDate = DateTime.Now,
                    Email = signp.Email,
                    IsConfirm = false,
                    Password = signp.Password.CreateSHA256(),
                    PhoneNumber = signp.PhoneNumber,
                    UserName = signp.UserName,
                    UserId = Guid.NewGuid()
                };
            });
        }


        public async Task<Users> GetUserByEmailAsync(string email)
        {
            return await Task.Run(async () => await _repository.UserRepository.GetFirstOrDefaultAsync(u => u.Email == email));
        }

        public async Task<Users> GetUserByUserNameAsync(string userName)
        {
            return await Task.Run(async () => await _repository.UserRepository.GetFirstOrDefaultAsync(u => u.UserName == userName));
        }

        public async Task<IEnumerable<Users>> GetUsersBySearchAsync(string q)
        {
            return await Task.Run(async () => await _repository.UserRepository.GetAllAsync(u => u.UserName.Contains(q) ||
            u.Email.Contains(q) ||
            u.PhoneNumber.Contains(q)));
        }

        public async Task<bool> IsExistAsync(Guid userId)
        {
            return await Task.Run(async () => await _repository.UserRepository.IsExistAsync(u => u.UserId == userId));
        }

        public async Task<bool> IsExistAsync(string userName)
        {
            return await Task.Run(async () => await _repository.UserRepository.IsExistAsync(u => u.UserName == userName));
        }

        public async Task<bool> IsExistAsync(Users user)
        {
            return await Task.Run(async () => await _repository.UserRepository.IsExistAsync(u => u.UserId == user.UserId &&
            u.UserName == user.UserName));
        }

    }
}
