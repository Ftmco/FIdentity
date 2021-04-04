using System;
using System.ComponentModel.DataAnnotations;

namespace FTeam.EntityNpanel.Sessions
{
    public record UsersSessions
    {
        public UsersSessions()
        {

        }

        [Key]
        public int UserSessionsId { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        public string Header { get; set; }

        [Required]
        public Guid UserId { get; set; }

        //Relationships 

        public virtual Users.Users Users { get; set; }
    }
}
