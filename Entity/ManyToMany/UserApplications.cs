using FTeam.Entity.Applications;
using System;
using System.ComponentModel.DataAnnotations;

namespace FTeam.EntityNpanel.ManyToMany
{
    public record UserApplications
    {
        public UserApplications()
        {

        }

        [Key]
        public int UserApplicationsId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid ApplicationId { get; set; }

        public virtual Users.Users Users { get; set; }

        public virtual Applications Applications { get; set; }
    }
}
