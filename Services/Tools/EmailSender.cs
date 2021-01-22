using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;

/// <summary>
/// Send Email Tool
/// </summary>
public class EmailSender
{

    /// <summary>
    /// Send Email Async
    /// </summary>
    /// <param name="emailModel">Email Model</param>
    /// <returns>
    /// String Status 
    /// Success Or Exeption Message
    /// </returns>
    public static async Task<string> Send(SendEmailModel emailModel)
    {
        return await Task.Run(() =>
        {
            try
            {
                SmtpClient SmtpClient = new SmtpClient(emailModel.Host);

                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(emailModel.Address, emailModel.DisplayName),
                    IsBodyHtml = true,
                    Subject = emailModel.Subject,
                    Body = emailModel.Body,
                };

                foreach (var item in emailModel.To)
                {
                    mail.To.Add(item);
                }
                //mail.Subject = Subject;
                //mail.Body = Body;
                //mail.IsBodyHtml = true;

                SmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpClient.Port = emailModel.SmptPort;
                SmtpClient.Credentials = new System.Net.NetworkCredential(emailModel.UserName, emailModel.Password);
                SmtpClient.EnableSsl = emailModel.EnableSsl;
                SmtpClient.Send(mail);
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        });
    }
      
}
