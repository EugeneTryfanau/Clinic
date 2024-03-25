using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notifications.BLL.Interfaces;
using Notifications.BLL.Models;
using Notifications.BLL.Services;

namespace Notifications.BLL
{
    public static class BllServiceExtentions
    {
        public static void AddBLLDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHostedService<RabbitMqListenerService>();

            services.Configure<EmailSettings>(emailSettings =>
            {
                emailSettings.Server = configuration["EmailSettings:Server"];
                emailSettings.Port = Convert.ToInt32(configuration["EmailSettings:Port"]);
                emailSettings.SenderEmail = configuration["EmailSettings:SenderEmail"];
                emailSettings.SenderName = configuration["EmailSettings:SenderName"];
                emailSettings.Username = configuration["EmailSettings:Username"];
                emailSettings.Password = configuration["EmailSettings:Password"];

            });

            services.AddSingleton<IEmailService, EmailService>();
        }
    }
}