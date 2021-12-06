using EstudoDDD.Domain.Entities.SendGrid;
using EstudoDDD.Domain.Interfaces;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoDDD.Service.SendGrid
{
    public class SendGridEmailSender : IEmailSender
    {
        public SendGridEmailSenderOptions Options { get; set; }

        public SendGridEmailSender(IOptions<SendGridEmailSenderOptions> options)
        {
            this.Options = options.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string templateId, TemplateData templateData)
        {
            await Execute(Options.ApiKey, subject, templateId, templateData, email);
        }

        private async Task<Response> Execute(string apiKey, string subject, string templateId, TemplateData templateData, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(Options.SenderEmail, Options.SenderName),
                Subject = subject
            };
            msg.AddTo(new EmailAddress(email));

            msg.SetTemplateId(templateId);
            msg.SetTemplateData(templateData);
            msg.SetClickTracking(false, false);
            msg.SetOpenTracking(false);
            msg.SetGoogleAnalytics(false);
            msg.SetSubscriptionTracking(false);
            return await client.SendEmailAsync(msg);
        }
    }
}