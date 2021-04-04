using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTeam.EntityNpanel.ManyToMany
{
    public record UserApplications
    {
        public UserApplications()
        {

        }

        [Key]
        public int UserApplicationsId { get; set; }
    }
}
