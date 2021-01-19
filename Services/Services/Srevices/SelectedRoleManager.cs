using Fri2Ends.Identity.Context;
using Fri2Ends.Identity.Services.Generic.UnitOfWork;
using Fri2Ends.Identity.Services.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Srevices
{
    public class SelectedRoleManager : ISelectedRoleManager
    {
        #region ::Dependency::

        private readonly IUnitOfWork<FIdentityContext> _repository;

        public SelectedRoleManager()
        {
            _repository = new UnitOfWork<FIdentityContext>();
        }

        #endregion

        public async Task<bool> IsExistAsync(Guid userId, Guid roleId)
        {
            return await Task.Run(async () => await _repository.SelectedRolesRepository.IsExistAsync(s => s.UserId == userId && s.RoleId == roleId));
        }

    }
}
