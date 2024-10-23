using System.Net.Mail;
using System.Net;
using System.Text;
using BloodDonationDatabase.Core.Services;

namespace BloodDonationDatabase.Infrastructure.Email
{
    public class EmailSender : IEmailSenderService
    {
        public void SendEmail(string toEmail, string subject)
        {
            // Set up SMTP client
            SmtpClient client = new SmtpClient("smtp.ethereal.email", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("abigale.bernier@ethereal.email", "16DZd6HqkZcP5YrTcR");

            // Create email message
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("abigale.bernier@ethereal.email");
            mailMessage.To.Add(toEmail);
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            StringBuilder mailBody = new StringBuilder();
            mailBody.AppendFormat("<h1>User Registered</h1>");
            mailBody.AppendFormat("<br />");
            mailBody.AppendFormat("<p>Thank you For Registering account</p>");
            mailMessage.Body = mailBody.ToString();

            // Send email
            client.Send(mailMessage);
        }
    }
}
