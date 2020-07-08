using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inide.WebServices.Constants;
using Inide.WebServices.Contracts;
using Inide.WebServices.Infrastructure.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inide.WebServices.Infrastructure.Installers
{
    public class RegisterSettings : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            
            var appSettingsSection = configuration.GetSection(AppWebService.SettingsApp);
            services.Configure<AppSettings>(appSettingsSection);

            var appConnectionsSection = configuration.GetSection(AppWebService.SettingsCnn);
            services.Configure<CnnSettings>(appConnectionsSection);
            
        }
    }
}
