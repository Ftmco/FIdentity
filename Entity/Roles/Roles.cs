using FTeam.EntityNpanel.ManyToMany;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FTeam.EntityNpanel.Roles
{
    public record Roles
    {
        public Roles()
        {

        }

        [Key]
        public Guid RoleId { get; set; }

        [Required]
        public string RoleName { get; set; }

        [Required]
        public string RoleTitle { get; set; }

        public virtual ICollection<UserRoles> UserRoles { get; set; }

        public virtual ICollection<RoleAccessPages> RoleAccessPages { get; set; }
    }
}
