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
    public static void Send(string To, string Subject, string Body, string DisplayName)
    {

        SmtpClient SmtpClient = new SmtpClient("smtp-mail.outlook.com");

        MailMessage mail = new MailMessage
        {
            From = new MailAddress("friendstmco@outlook.com", DisplayName),
            IsBodyHtml = true,
            Subject = Subject,
            Body = Body,
        };

        mail.To.Add(To);

        //mail.Subject = Subject;
        //mail.Body = Body;
        //mail.IsBodyHtml = true;

        SmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        SmtpClient.UseDefaultCredentials = false;
        SmtpClient.Port = 587;
        SmtpClient.Credentials = new System.Net.NetworkCredential("friendstmco@outlook.com", "FD3445*54lKD");
        SmtpClient.EnableSsl = false;
        SmtpClient.Send(mail);
    }

}
