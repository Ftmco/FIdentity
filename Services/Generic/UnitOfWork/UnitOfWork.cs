using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Generic.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext, new()
    {
        #region ::Dependency::

        /// <summary>
        /// Generic Data Base Context
        /// </summary>
        private DbContext _db;

        public UnitOfWork()
        {
            _db = new TContext();
        }

        #endregion

        #region ::User Repository::

        private IGenericRepository<Users> _userRepository;

        public IGenericRepository<Users> UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new GenericServices<Users>(_db);
                }
                return _userRepository;
            }
            init => throw new NotImplementedException();
        }

        #endregion

        #region __Save __ Dispose__

        public async void Dispose()
        {
            await _db.DisposeAsync();
        }

        public bool Save()
        {
            try
            {
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> SaveAsync()
        {
            return await Task.Run(async () =>
            {
                try
                {
                    await _db.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        #endregion
    }
}
