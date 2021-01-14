using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Generic.UnitOfWork
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {
        /// <summary>
        /// Users Repository
        /// </summary>
        IGenericRepository<Users> UserRepository { get; init; }

        /// <summary>
        /// Roles Repository
        /// </summary>
        IGenericRepository<Roles> RolesRepository { get; init; }

        /// <summary>
        /// Selected Roles Repository
        /// </summary>
        IGenericRepository<SelectedRoles> SelectedRolesRepository { get; init; }

        /// <summary>
        /// Users Token Repository
        /// </summary>
        IGenericRepository<Tokens> TokensRepository { get; init; }

        /// <summary>
        /// Login Logs Repository
        /// </summary>
        IGenericRepository<LoginLogs> LoginLogsRepository { get; init; }


        /// <summary>
        /// Save All Changes Async
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveAsync();

        /// <summary>
        /// Change All Changes Sync
        /// </summary>
        /// <returns></returns>
        bool Save();
    }
}
