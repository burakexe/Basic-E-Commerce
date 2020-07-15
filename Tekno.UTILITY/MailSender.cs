using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Tekno.UTILITY
{
    public class MailSender
    {
        public static void SendEmail(string email, string subject, string message)
        {
            //Mail gönderim ayarları
            MailMessage sender = new MailMessage();
            sender.From = new MailAddress("burakgider@hotmail.com", "Burak Gider");
            sender.To.Add(email);
            sender.Subject = subject;
            sender.Body = message;

            //Smtp ayarları
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("burakgider@hotmail.com", "Burak");
            smtp.Port = 587;
            smtp.Host = "SMTP.office365.com";
            smtp.EnableSsl = false;
            smtp.Send(sender);

        }
    }
}
