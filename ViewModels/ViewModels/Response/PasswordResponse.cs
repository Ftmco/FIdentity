
/// <summary>
/// Change Password Response
/// </summary>
public enum ChangePasswordResponse
{
    Success = 0,
    UserNotFound = -1,
    Exception = -2,
    WrongOldPassword = -3
}

/// <summary>
/// Recovey Password Response
/// </summary>
public enum RecoveryPasswordResponse
{
    Success = 0,
    UserNotFound = -1,
    Exception = -2,
    WrongRecoveryCode = -3
}

/// <summary>
/// Set New Password
/// </summary>
public enum SetPasswordResponse
{
    Success = 0,
    UserNotFound = -1,
    Exception = -2
}