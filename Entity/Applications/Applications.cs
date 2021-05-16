using FTeam.Entity.Sessions;
using FTeam.EntityNpanel.ManyToMany;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FTeam.Entity.Applications
{
    public record Applications
    {
        public Applications()
        {

        }

        [Key]
        public Guid Id { get; set; }

        [Display(Name = "نام اپلیکیشن")]
        [Required]
        public string ApplicationName { get; set; }

        [Display(Name = "ایمیل اپلیکیشن")]
        [Required]
        public string ApplicationEmail { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required]
        public string ApplicationPassword { get; set; }

        [Display(Name = "فعال")]
        [Required]
        public bool IsConfirm { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        [Required]
        public DateTime CreateDate { get; set; }

        [Display(Name = "ایکن اپلیکیشن")]
        public string ApplicationIcon { get; set; }

        //Relationships 
        //Navigation Properties 

        public virtual ICollection<ApplicationSessions> ApplicationSessions { get; set; }

        public virtual ICollection<UserApplications> UserApplications { get; set; }
    }
}
