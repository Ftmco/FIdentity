using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTeam.EntityNpanel.Roles
{
    public record Roles
    {
        public Roles()
        {

        }

        [Key]
        public Guid RoleId { get; set; }
    }
}
