using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Features Entity
/// </summary>
public record AppFeatures
{
    public AppFeatures()
    {

    }

    /// <summary>
    /// Primary Key
    /// </summary>
    [Key]
    public Guid FeatureId { get; set; }

    /// <summary>
    /// Feature Title
    /// </summary>
    [Display(Name = "Feature Title")]
    [Required]
    [MaxLength(150)]
    [MinLength(3)]
    public string FeatureTitle { get; set; }

    /// <summary>
    /// Feature Name
    /// </summary>
    [Display(Name = "Feature Name")]
    [Required]
    [MaxLength(150)]
    [MinLength(3)]
    public string FeatureName { get; set; }

    /// <summary>
    /// About Feature
    /// </summary>
    [Display(Name = "Feature Title")]
    [Required]
    [DataType(DataType.MultilineText)]
    public string ShurtDescription { get; set; }

    /// <summary>
    /// Insert Date 
    /// </summary>
    [Required]
    public DateTime CreateDate { get; set; }

    public virtual List<AppSelectedFeatures> AppSelectedFeatures { get; set; }
}