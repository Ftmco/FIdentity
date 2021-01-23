using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Owner Apps 
/// </summary>
public record Owner
{
    public Owner()
    {

    }

    /// <summary>
    /// Primary Key
    /// </summary>
    [Key]
    public Guid OwnerId { get; set; }

    /// <summary>
    /// Owner Token
    /// </summary>
    [Required]
    public string OwnerToken { get; set; }

    /// <summary>
    /// Users Forgen Key
    /// </summary>
    [Required]
    public Guid UserId { get; set; }

    //Relationships 

    /// <summary>
    /// Relationships With Apps
    /// </summary>
    public virtual List<Apps> Apps { get; set; }

    /// <summary>
    /// Users Relationships
    /// </summary>
    public virtual Users Users { get; set; }
}