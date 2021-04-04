using FTeam.EntityNpanel.ManyToMany;
using FTeam.EntityNpanel.Sessions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FTeam.EntityNpanel.Users
{
    public record Users
    {
        public Users()
        {

        }

        [Key]
        public Guid UserId { get; set; }

        [Display(Name = "User Name")]
        [Required]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [Phone]
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string ActiveCode { get; set; }

        [Required]
        public bool IsConfirm { get; set; }

        [Display(Name = "Profile Image")]
        public string ImageName { get; set; }

        [Display(Name = "Active Date")]
        [Required]
        public DateTime ActiveDate { get; set; }

        [PasswordPropertyText]
        [Required]
        public string Password { get; set; }

        //Relationships

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<UsersSessions> UsersSessions { get; set; }

        public virtual ICollection<UserRoles> UserRoles { get; set; }

        public virtual ICollection<UserApplications> UserApplications { get; set; }
    }
}
