using Microsoft.EntityFrameworkCore;
using System;
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

        #region ::Roles Repository::

        private IGenericRepository<Roles> _roleRepository;

        public IGenericRepository<Roles> RolesRepository
        {
            get
            {
                if (_roleRepository == null)
                {
                    _roleRepository = new GenericServices<Roles>(_db);
                }
                return _roleRepository;
            }
            init => throw new NotImplementedException();
        }

        #endregion

        #region ::Selected Role Repository::

        private IGenericRepository<SelectedRoles> _selectedRoleRepository;

        public IGenericRepository<SelectedRoles> SelectedRolesRepository
        {
            get
            {
                if (_selectedRoleRepository == null)
                {
                    _selectedRoleRepository = new GenericServices<SelectedRoles>(_db);
                }
                return _selectedRoleRepository;
            }
            init => throw new NotImplementedException();
        }

        #endregion

        #region ::Token Repository::

        private IGenericRepository<Tokens> _tokenRepository;

        public IGenericRepository<Tokens> TokensRepository
        {
            get
            {
                if (_tokenRepository == null)
                {
                    _tokenRepository = new GenericServices<Tokens>(_db);
                }
                return _tokenRepository;
            }
            init => throw new NotImplementedException();
        }

        #endregion

        #region ::Login Logs Repository::

        private IGenericRepository<LoginLogs> _loginLogsRepository;

        public IGenericRepository<LoginLogs> LoginLogsRepository
        {
            get
            {
                if (_loginLogsRepository == null)
                {
                    _loginLogsRepository = new GenericServices<LoginLogs>(_db);
                }
                return _loginLogsRepository;
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
