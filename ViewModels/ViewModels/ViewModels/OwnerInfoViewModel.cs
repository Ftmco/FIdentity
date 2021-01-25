using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record OwnerInfoViewModel
{
    public Guid OwnerId { get; set; }
    public string UserProfileImageName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public int AppCount { get; set; }
    public string Token { get; set; }
}

public enum OwnerShipRequestStatus
{
    Success = 0,
    UserNotfound = -1,
    Exception = -2,
    CoExist = -3
}