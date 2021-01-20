using System.ComponentModel.DataAnnotations;

/// <summary>
/// Change User Login Password
/// </summary>
public record ChangePasswordViewModel
{
    /// <summary>
    /// Old Password
    /// </summary>
    [Display(Name = "Old Password")]
    [Required]
    [DataType(DataType.Password)]
    public string OldPassword { get; set; }

    /// <summary>
    /// New Password
    /// </summary>
    [Display(Name = "New Password")]
    [Required]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; }

    /// <summary>
    /// Confirm Password
    /// </summary>
    [Display(Name = "Confirm Password")]
    [Required]
    [DataType(DataType.Password)]
    [Compare("NewPassword")]
    public string ReNewPassword { get; set; }
}

/// <summary>
/// Recovey Password View Model
/// </summary>
public record RecoveryPasswordViewModel
{
    /// <summary>
    /// Email Address
    /// </summary>
    [Display(Name = "Email")]
    [Required]
    public string Email { get; set; }

    /// <summary>
    /// Recovey Code 
    /// User Active Code
    /// </summary>
    [Display(Name = "Recovey Code")]
    public string RecoveryCode { get; set; }

    /// <summary>
    /// New Password
    /// </summary>
    [Display(Name = "New Password")]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; }

    /// <summary>
    /// Confirm Password
    /// </summary>
    [Display(Name = "Confirm Password")]
    [DataType(DataType.Password)]
    [Compare("NewPassword")]
    public string ReNewPassword { get; set; }
}