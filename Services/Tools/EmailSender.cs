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
}
