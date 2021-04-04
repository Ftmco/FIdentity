using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTeam.EntityNpanel.Sessions
{
    public record UsersSessions
    {
        public UsersSessions()
        {

        }

        [Key]
        public int UserSessionsId { get; set; }
    }
}
