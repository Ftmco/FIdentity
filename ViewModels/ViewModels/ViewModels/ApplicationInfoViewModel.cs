using System.Collections.Generic;

/// <summary>
/// Application Information View Model
/// </summary>
public record ApplicationInfoViewModel
{
    /// <summary>
    /// Request Status
    /// </summary>
    public ApplicationInfoStatus Status { get; set; }

    /// <summary>
    /// App 
    /// </summary>
    public Apps App { get; set; }

    /// <summary>
    /// Owner
    /// </summary>
    public Users User { get; set; }

    /// <summary>
    /// App Features
    /// </summary>
    public IList<AppFeatures> Features { get; set; }
}

public enum ApplicationInfoStatus
{
    Success = 0,
    AppNotfound = -1,
    Exception = -2
}
