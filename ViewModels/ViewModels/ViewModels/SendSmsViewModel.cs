/// <summary>
/// Send Sms Model
/// </summary>
public record SendSms
{
    /// <summary>
    /// Sned To Mobile Number
    /// </summary>
    public string SmsSendTo { get; set; }

    /// <summary>
    /// Sms Text
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Sahar Sms Api Key
    /// </summary>
    public string ApiKey { get; set; }

    /// <summary>
    /// Sahar Sms Template
    /// </summary>
    public string Template { get; set; }
}