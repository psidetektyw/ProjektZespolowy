using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Schronisko.Helpers
{
    public static class MailHelper
    {
        public static void SendMessage(string to, string body, string subject)
        {
            //MailMessage mail = new MailMessage("psidetektyw22@gmail.com", to);
            //SmtpClient client = new SmtpClient();
            //client.Port = 587;
            //client.EnableSsl = true;//wrazie co false
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //client.UseDefaultCredentials = false;
            //client.Host = "smtp.gmail.com";
            //client.Credentials = new System.Net.NetworkCredential("psidetektyw22@gmail.com", "sidetektyw");
            ////mail.To.Add(new MailAddress("user@hotmail.com"));
            //mail.Subject = subject;
            //mail.Body = body;
            //client.Send(mail);

            var fromAddress = new MailAddress("psidetektyw22@gmail.com", "Psidetektyw22");
            var toAddress = new MailAddress(to);
            const string fromPassword = "Psidetektyw";
           

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }

    }
}