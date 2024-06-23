using CookBook.BuisnesLogic.Models;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace CookBook.BuisnesLogic.Services.UserServices
{
    public class EmailService
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MailMessage();
            emailMessage.From = new MailAddress(_smtpSettings.SenderEmail);
            emailMessage.To.Add(new MailAddress(email));
            emailMessage.Subject = subject;
            emailMessage.Body = message;

            using var client = new SmtpClient(_smtpSettings.Server)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(_smtpSettings.SenderEmail, _smtpSettings.Password),
                Port = 587
            };            
            try
            {
                client.Send(emailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email: {ex.Message}");
            }
        }
    }
}