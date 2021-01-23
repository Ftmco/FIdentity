using System;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Selected Features Entity
/// </summary>
public record AppSelectedFeatures
{
    public AppSelectedFeatures()
    {

    }

    /// <summary>
    /// Primary Key
    /// </summary>
    [Key]
    public Guid SelectedId { get; set; }

    /// <summary>
    /// Apps Forgen Key
    /// </summary>
    [Required]
    public Guid AppId { get; set; }

    /// <summary>
    /// Features Forgen Key
    /// </summary>
    [Required]
    public Guid FeatureId { get; set; }

    //Relationships 

    /// <summary>
    /// Relationships With Apps
    /// </summary>
    public virtual Apps Apps { get; set; }

    /// <summary>
    /// Relationships With Features
    /// </summary>
    public virtual AppFeatures AppFeatures { get; set; }
}