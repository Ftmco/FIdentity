using System.Collections.Generic;

public record ApplicationInfoViewModel
{
    public ApplicationInfoStatus Status { get; set; }
    public Apps App { get; set; }
    public Users User { get; set; }
    public IList<AppFeatures> Features { get; set; }
}

public enum ApplicationInfoStatus
{
    Success = 0,
    AppNotfound = -1,
    Exception = -2
}