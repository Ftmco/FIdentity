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

    public int TokenType { get; set; }

    /// <summary>
    /// Relationships Users
    /// </summary>
    public virtual List<Users> Users { get; set; }
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