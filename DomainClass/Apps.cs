using System;
using System.Collections.Generic;

/// <summary>
/// App Tokens
/// </summary>
public record Apps
{
    /// <summary>
    /// App Id
    /// </summary>
    public Guid AppId { get; set; }

    /// <summary>
    /// App Token
    /// </summary>
    public string AppToken { get; set; }

    /// <summary>
    /// Create Token Date
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// Relationships Users
    /// </summary>
    public virtual List<Users> Users { get; set; }
}