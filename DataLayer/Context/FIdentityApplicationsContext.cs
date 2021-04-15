using Microsoft.EntityFrameworkCore;

namespace FTeam.DataLayer.Context
{
    public class FIdentityApplicationsContext : DbContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=45.82.139.103;Initial Catalog=ApplicationsIdentity;user Id=sa;password=1G14ijWA**//");
        }
    }
}
