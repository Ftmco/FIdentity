using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum CreateAppResponse
{
    Success = 0,
    OwnerNotFound = -1,
    Exception = -2
}

public enum DeleteAppStatus
{
    Success = 0,
    AppNotFound = -1,
    AccessDenied = -3,
    Exception = -2
}