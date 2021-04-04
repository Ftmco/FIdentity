using FTeam.Entity.Applications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTeam.Entity.Sessions
{
    public record ApplicationSessions
    {
        public ApplicationSessions()
        {

        }

        [Key]
        public int SessionId { get; set; }

        [Required]
        public DateTime SetDate { get; set; }

        [Required]
        public DateTime ExpireDate { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        public string Header { get; set; }

        [Required]
        public Guid ApplicationId { get; set; }

        //Relationships 
        //Navigation Properties

        public virtual Applications.Applications Applications { get; set; }
    }
}
