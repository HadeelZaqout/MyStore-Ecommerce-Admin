using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MyStore.Options;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace MyStore.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly SmtpOptions smtpoptions;

        public EmailSender(IOptions<SmtpOptions> smtpoptions)
        {
            this.smtpoptions = smtpoptions.Value;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try {
                var body = new TextPart(MimeKit.Text.TextFormat.Html);
                body.Text = htmlMessage;

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(smtpoptions.SenderName,smtpoptions.SenderEmail));
                message.Subject = subject;
                message.To.Add(new MailboxAddress(null, email));
                message.Body=body;
                var client = new SmtpClient();
                await  client.ConnectAsync(smtpoptions.Host, smtpoptions.Port);
                await client.AuthenticateAsync(smtpoptions.SenderEmail, smtpoptions.Password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
            catch (Exception er) { }
        }
    }
}
