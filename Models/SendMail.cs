using System.Net.Mail;
using System.Net;
using Twilio.Http;
using System.Net.Mime;
using System.Text;
using Microsoft.VisualBasic;

namespace Zencareservice.Models
{
    public class SendMail
    {
     
        public string EmailSend(string From, string To, string Pass, string Subject, string Mailbody, string host, int port)
        {
            try
            {
                MailMessage message = new MailMessage();
                //SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(From);
                message.To.Add(new MailAddress(To));
                
                message.Subject = Subject;
                message.IsBodyHtml = true; 
                message.Body = Mailbody;

                //AlternateView htmlView = AlternateView.CreateAlternateViewFromString(Mailbody, null, "~/forms/termsofservice.html");

                // Load the HTML file and embed the image
                //LinkedResource imageResource = new LinkedResource(imagePath, "~/image/jpeg");
                //imageResource.ContentId = Guid.NewGuid().ToString(); // Content-ID for the image

                // Embed the image in the HTML view
                //htmlView.LinkedResources.Add(imageResource);

                // Attach the HTML view to the email
                //message.AlternateViews.Add(htmlView);

                using (SmtpClient smtpClient = new SmtpClient())
                {
                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.Credentials = new NetworkCredential(From, Pass);                  
                    smtpClient.Send(message);
  
                  
                }

            }
            catch (Exception ex)
            {
				throw ex;
                
            

            }
            return ("Success");
        }
    }
}
