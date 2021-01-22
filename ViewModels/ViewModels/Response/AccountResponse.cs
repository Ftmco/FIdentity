/// <summary>
/// Signup Response
/// </summary>
public enum SignUpResponse
{
    /// <summary>
    /// SignUp SuccessFully
    /// </summary>
    Success = 0,

    /// <summary>
    /// System Exceptions
    /// </summary>
    Exception = -2,

    /// <summary>
    /// User Exist
    /// </summary>
    UserAlreadyExist = -3,

    /// <summary>
    /// Application Code Is Not Exist
    /// </summary>
    AppNotFound = -4,

    /// <summary>
    /// Applications In Not Active
    /// </summary>
    AppActivent = -5,

    /// <summary>
    /// User Is Not Owner To App
    /// </summary>
    AppIsntForYou = -6
}

/// <summary>
/// Login Response
/// </summary>
public record LoginResponse
{
    /// <summary>
    /// Login Succes 
    /// Set Key and Value For Sessions or Cookies
    /// </summary>
    public Success Success { get; set; }

    /// <summary>
    /// Action Status
    /// </summary>
    public LoginStatus Status { get; set; }
}

/// <summary>
/// Login Status
/// </summary>
public enum LoginStatus
{
    Success = 0,
    Exception = -2,
    WrongPassword = -3,
    UserNotFound = -4
}

public record ActivationResponse
{
    public ActivationResponseEn Status { get; set; }

    public Success Success { get; set; }
}

public enum ActivationResponseEn
{
    /// <summary>
    /// Actived User 
    /// </summary>
    Success = 0,

    /// <summary>
    /// Not Found Any User
    /// </summary>
    UserNotFound = -1,

    /// <summary>
    /// Wrong Active Code 
    /// </summary>
    WrongActiveCode = -3,

    /// <summary>
    /// System Exceptions
    /// </summary>
    Exception = -2
}

public enum DeleteAccountResponse
{
    /// <summary>
    /// Delete User 
    /// </summary>
    Success = 0,

    /// <summary>
    /// Wrong DeleteCode Code 
    /// </summary>
    WrongDeleteCode = -1,

    /// <summary>
    /// System Exceptions
    /// </summary>
    Exception = -2
}

/// <summary>
/// Success Type Response
/// </summary>
public record Success
{
    /// <summary>
    /// Is Success
    /// </summary>
    public bool IsSucces { get; init; } = true;

    /// <summary>
    /// Token Key 
    /// </summary>
    public string Key { get; init; }

    /// <summary>
    /// Token Value
    /// </summary>
    public string Value { get; init; }
}