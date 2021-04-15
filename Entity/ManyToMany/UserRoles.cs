using FTeam.EntityNpanel.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTeam.EntityNpanel.ManyToMany
{
    public record UserRoles
    {
        public UserRoles()
        {

        }

        [Key]
        public int UserRolesId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid RoleId { get; set; }

        public virtual Users.Users Users { get; set; }

        public virtual Roles.Roles Roles { get; set; }
    }
}
