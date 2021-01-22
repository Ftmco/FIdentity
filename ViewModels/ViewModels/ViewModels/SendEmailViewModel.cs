using System.Collections.Generic;

/// <summary>
/// Send Email Model
/// </summary>
public record SendEmailModel
{
    /// <summary>
    /// Email Address 
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Send Mail To???
    /// </summary>
    public IList<string> To { get; set; }

    /// <summary>
    /// Mail Subject
    /// </summary>
    public string Subject { get; set; }

    /// <summary>
    /// Mail Body
    /// </summary>
    public string Body { get; set; }

    /// <summary>
    /// Mail Display Name
    /// </summary>
    public string DisplayName { get; set; }

    /// <summary>
    /// Smtp Host
    /// </summary>
    public string Host { get; set; }

    /// <summary>
    /// Send Email From
    /// </summary>
    public string EmailFrom { get; set; }

    /// <summary>
    /// Email User Name For Login
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// Email Password For Login
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Smtp Server Port
    /// </summary>
    public int SmptPort { get; set; }

    /// <summary>
    /// Enable SSL 
    /// </summary>
    public bool EnableSsl { get; set; }
}