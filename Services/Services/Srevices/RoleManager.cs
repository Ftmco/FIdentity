using Fri2Ends.Identity.Context;
using Fri2Ends.Identity.Services.Generic.UnitOfWork;
using Fri2Ends.Identity.Services.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Srevices
{
    public class RoleManager : IRoleManager
    {
        #region __Dependency__

        private readonly IUnitOfWork<FIdentityContext> _repository;

        public RoleManager()
        {
            _repository = new UnitOfWork<FIdentityContext>();
        }

        #endregion

        public async Task<Roles> GetRoleByNameAsync(string roleName)
        {
            return await Task.Run(async () =>
            {
                var role = await _repository.RolesRepository.GetFirstOrDefaultAsync(r => r.RoleName == roleName);
                return role;
            });
        }

        public async Task<IEnumerable<Roles>> GetRolesBySearchAsync(string q)
        {
            return await Task.Run(async () =>
                 await _repository.RolesRepository.GetAllAsync(r => r.RoleName.Contains(q) || r.RoleTitle.Contains(q)));
        }
    }
}
