using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using VSTrain.Core.Contracts.Infrastructure;
using VSTrain.Core.Entities;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace VSTrain.Infrastructure
{
    public class EmailService : IEmailService
    {
        private EmailSettings emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            this.emailSettings = emailSettings.Value;
        }
        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(emailSettings.ApiKey);
            var to = new EmailAddress(email.To);
            var from = new EmailAddress(emailSettings.FromAddress, emailSettings.FromName);
            var subject = email.Subject;
            var body = email.Body;
            var sendGridMessage = MailHelper.CreateSingleEmail(from,to,subject,body,body);
            var response = await client.SendEmailAsync(sendGridMessage);
            if(response.StatusCode == System.Net.HttpStatusCode.Accepted || 
              response.StatusCode == System.Net.HttpStatusCode.OK){
                  return true;

            }
            return false;
        }
    }
}