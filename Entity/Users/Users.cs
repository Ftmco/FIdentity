using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTeam.EntityNpanel.Users
{
    public record Users
    {
        public Users()
        {

        }

        [Key]
        public Guid UserId { get; set; }
    }
}
