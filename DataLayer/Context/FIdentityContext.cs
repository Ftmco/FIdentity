using Microsoft.EntityFrameworkCore;

namespace Fri2Ends.Identity.Context
{
    public class FIdentityContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=FIdentity;Integrated Security=True;MultipleActiveResultSets=True;");
        }

        /// <summary>
        /// Roles Table
        /// </summary>
        public DbSet<Roles> Roles { get; set; }

        /// <summary>
        /// Selected User Roles
        /// </summary>
        public DbSet<SelectedRoles> SelectedRoles { get; set; }

        /// <summary>
        /// Users
        /// </summary>
        public DbSet<Users> Users { get; set; }

        /// <summary>
        /// User Tokens
        /// </summary>
        public DbSet<Tokens> Tokens { get; set; }

        /// <summary>
        /// Login Logs
        /// </summary>
        public DbSet<LoginLogs> LoginLogs { get; set; }

        /// <summary>
        /// Apps
        /// </summary>
        public DbSet<Apps> Apps { get; set; }

        /// <summary>
        /// App Features
        /// </summary>
        public DbSet<AppFeatures> AppFeatures { get; set; }

        /// <summary>
        /// App Selected  Features
        /// </summary>
        public DbSet<AppSelectedFeatures> AppSelectedFeatures { get; set; }

        /// <summary>
        /// User Apps 
        /// </summary>
        public DbSet<UserApps> UserApps { get; set; }
    }
}
