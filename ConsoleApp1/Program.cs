using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            EmailSender.Send("amir0hossin0pr@gmail.com", "TEST", "JUST TEST From FTM CO ", "FTMCO");
            Console.WriteLine("Hello World!");
        }
    }

    public class EmailSender
    {
        public static void Send(string To, string Subject, string Body, string DisplayName)
        {

            SmtpClient SmtpClient = new SmtpClient("smtp.gmail.com");

            MailMessage mail = new MailMessage
            {
                From = new MailAddress("ftmcoends@gmail.com", DisplayName),
                IsBodyHtml = true,
                Subject = Subject,
                Body = Body,
            };

            mail.To.Add(To);

            //mail.Subject = Subject;
            //mail.Body = Body;
            //mail.IsBodyHtml = true;
            SmtpClient.UseDefaultCredentials = true;
            SmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpClient.UseDefaultCredentials = false;
            SmtpClient.EnableSsl = false;
            SmtpClient.Port = 587;
            
            
            SmtpClient.Credentials = new System.Net.NetworkCredential("ftmcoends@gmail.com", "1G14ijWA");
            SmtpClient.EnableSsl = false;
            SmtpClient.Send(mail);
        }

    }
}
