using System;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// User Joined Apps
/// </summary>
public record UserApps
{
    public UserApps()
    {

    }

    /// <summary>
    /// Primary Key
    /// </summary>
    [Key]
    public Guid UserAppsId { get; set; }

    /// <summary>
    /// Forgen Key Apps
    /// </summary>
    [Required]
    public string AppToken { get; set; }

    /// <summary>
    /// Forgen Key User
    /// </summary>
    [Required]
    public Guid UserId { get; set; }

    /// <summary>
    /// Join App Date
    /// </summary>
    [Required]
    public DateTime JoindeDate { get; set; }

    //Relationships 

    /// <summary>
    /// Users Relationships
    /// </summary>
    public virtual Users Users { get; set; }

}
