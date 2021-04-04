using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTeam.EntityNpanel.Roles
{
    public record Pages
    {
        public Pages()
        {

        }

        [Key]
        public Guid PageId { get; set; }
    }
}
