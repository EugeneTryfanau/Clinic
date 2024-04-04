using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using Notifications.BLL.Interfaces;
using Notifications.BLL.Models;
using Notifications.BLL.Templates;
using System.Reflection;
using RazorLight;

namespace Notifications.BLL.Services
{
    public class EmailService(IOptions<EmailSettings> emailSettingsOptions) : IEmailService
    {
        private readonly EmailSettings _emailSettings = emailSettingsOptions.Value;

        public async Task<bool> SendMail(EmailModel mailModel, ICollection<string> recipients)
        {
            try
            {
                using (MimeMessage emailMessage = new MimeMessage())
                {
                    await PrepareMailMessage(emailMessage, mailModel, recipients);

                    using (SmtpClient mailClient = new SmtpClient())
                    {
                        await mailClient.ConnectAsync(_emailSettings.Server, _emailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                        await mailClient.AuthenticateAsync(_emailSettings.Username, _emailSettings.Password);
                        await mailClient.SendAsync(emailMessage);
                        await mailClient.DisconnectAsync(true);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private async Task<MimeMessage> PrepareMailMessage(MimeMessage message, EmailModel emailModel, ICollection<string> recipients)
        {
            MailboxAddress emailFrom = new MailboxAddress(_emailSettings.SenderName, _emailSettings.SenderEmail);
            message.From.Add(emailFrom);

            foreach (var recipient in recipients)
                message.To.Add(new MailboxAddress("", recipient));

            message.Subject = emailModel.EmailSubject;

            BodyBuilder emailBodyBuilder = new BodyBuilder();
            emailBodyBuilder.TextBody = emailModel.EmailBody;
            emailBodyBuilder.HtmlBody = await GetFilledTemplate(emailBodyBuilder.TextBody!);

            message.Body = emailBodyBuilder.ToMessageBody();

            return message;
        }

        private static async Task<string> GetFilledTemplate(string message)
        {
            string template = EmailTemplates.DefaultEmailTemplate;

            RazorLightEngine engine = new RazorLightEngineBuilder()
                .UseEmbeddedResourcesProject(Assembly.GetEntryAssembly())
                .Build();

            string result = await engine.CompileRenderStringAsync(
                "cacheKey",
                template,
                message
                );

            return result;
        }
    }
}