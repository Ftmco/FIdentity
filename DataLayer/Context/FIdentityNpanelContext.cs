using FTeam.Entity.Applications;
using FTeam.Entity.Sessions;
using FTeam.EntityNpanel.ManyToMany;
using FTeam.EntityNpanel.Roles;
using FTeam.EntityNpanel.Sessions;
using FTeam.EntityNpanel.Users;
using Microsoft.EntityFrameworkCore;

namespace FTeam.DataLayer.Context
{
    public class FIdentityNpanelContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }

        public DbSet<Users> Users { get; set; }

        public DbSet<Roles> Roles { get; set; }

        public DbSet<RoleAccessPages> RoleAccessPages { get; set; }

        public DbSet<UserRoles> UserRoles { get; set; }

        public DbSet<Applications> Applications { get; set; }

        public DbSet<UserApplications> UserApplications { get; set; }

        public DbSet<Pages> Pages { get; set; }

        public DbSet<ApplicationSessions> ApplicationSessions { get; set; }

        public DbSet<UsersSessions> UsersSessions { get; set; }

    }
}
