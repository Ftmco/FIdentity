using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// App Tokens
/// </summary>
public record Apps
{
    /// <summary>
    /// App Id
    /// </summary>
    [Key]
    public Guid AppId { get; set; }

    /// <summary>
    /// Application Owner
    /// </summary>
    [Required]
    public Guid OwnerId { get; set; }

    /// <summary>
    /// App Token
    /// </summary>
    [Required]
    public string AppToken { get; set; }

    /// <summary>
    /// Application Title
    /// </summary>
    [Required]
    public string AppTitle { get; set; }

    /// <summary>
    /// Create Token Date
    /// </summary>
    [Required]
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// App Token Type
    /// From Token Type Enum
    /// </summary>
    [Required]
    public int TokenType { get; set; }

    /// <summary>
    /// App Is Active
    /// </summary>
    [Required]
    public bool IsActive { get; set; }

    /// <summary>
    /// Relationships Users
    /// </summary>
    public virtual List<Users> Users { get; set; }

    /// <summary>
    /// Relationships App Selected Features
    /// </summary>
    public virtual List<AppSelectedFeatures> AppSelectedFeatures { get; set; }

    /// <summary>
    /// Users App Relationships
    /// </summary>
    public virtual List<UserApps> UserApps { get; set; }

    /// <summary>
    /// Owner Relationships
    /// </summary>
    public virtual Owner Owner { get; set; }
}

/// <summary>
/// App Token Type
/// </summary>
public enum AppTokenType
{
    /// <summary>
    /// Global Access
    /// </summary>
    Global = 0,

    /// <summary>
    /// Private Access
    /// </summary>
    Private = 1,

    /// <summary>
    /// Public Access
    /// </summary>
    Public = 2,
}