using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Send Email Tool
/// </summary>
public class EmailSender
{
    public static async Task<string> Send(SendEmailModel emailModel)
    {
        return await Task.Run(async () =>
        {
            try
            {
                SmtpClient SmtpClient = new SmtpClient(emailModel.SmtpServer);

                MailMessage mail = new MailMessage
                {
                    From = new MailAddress("friendstmco@outlook.com", emailModel.DisplayName),
                    IsBodyHtml = true,
                    Subject = emailModel.Subject,
                    Body = emailModel.Body,
                };

                mail.To.Add(To);

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
            catch(Exception ex)
            {
                return ex.Message;
            }
        })
    }

    public record SendEmailModel
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string DisplayName { get; set; }
        public string SmtpServer { get; set; }
        public string EmailFrom { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int SmptPort { get; set; }
        public bool EnableSsl { get; set; }
    }
}
