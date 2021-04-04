using FTeam.EntityNpanel.Roles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTeam.EntityNpanel.ManyToMany
{
    public record RoleAccessPages
    {
        public RoleAccessPages()
        {

        }

        [Key]
        public int RoleAccessId { get; set; }

        [Required]
        public Guid RoleId { get; set; }

        [Required]
        public Guid PageId { get; set; }

        public virtual Roles.Roles Roles { get; set; }

        public virtual Pages Pages { get; set; }
    }
}
