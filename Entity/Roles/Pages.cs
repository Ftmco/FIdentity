using FTeam.EntityNpanel.ManyToMany;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FTeam.EntityNpanel.Roles
{
    public record Pages
    {
        public Pages()
        {

        }

        [Key]
        public Guid PageId { get; set; }

        [Required]
        public string PageName { get; set; }

        [Required]
        public string Url { get; set; }

        public virtual ICollection<RoleAccessPages> RoleAccessPages { get; set; }

    }
}
