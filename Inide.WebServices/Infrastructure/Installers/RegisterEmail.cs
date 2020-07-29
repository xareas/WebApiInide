using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Inide.WebServices.Constants;
using Inide.WebServices.Contracts;
using Inide.WebServices.Infrastructure.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inide.WebServices.Infrastructure.Installers
{
    public class RegisterEmail : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            var emailConfig = configuration
                .GetSection(AppConst.SettingsEmail)
                .Get<EmailSettings>();
            
            //Configuracion por defecto
            //services.AddSingleton(emailConfig);

            var smtpClient = new SmtpClient(emailConfig.SmtpServer, emailConfig.Port)
            {
                Credentials = new NetworkCredential(emailConfig.UserName,emailConfig.Password),
                EnableSsl = emailConfig.EnableSsl,
            };

            //Configuramos Fluent Email
            services.AddFluentEmail(emailConfig.From,emailConfig.FromName)
                    .AddRazorRenderer()
                    .AddSmtpSender(smtpClient);

        }
    }
}
