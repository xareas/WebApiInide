using Inide.WebServices.Contracts;
using Inide.WebServices.Infrastructure.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using Inide.WebServices.Constants;

namespace Inide.WebServices.Infrastructure.Installers
{
    internal class RegisterHealthChecks : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration config)
        {
            //Register HealthChecks and UI
            services.AddHealthChecks()
                    .AddCheck("Google Ping", new PingHealthCheck("www.google.com", 100))
                    .AddCheck("Bing Ping", new PingHealthCheck("www.bing.com", 100))
                    .AddUrlGroup(new Uri(config["ApiResourceBaseUrls:AuthServer"]),
                                name: "Auth Server",
                                failureStatus: HealthStatus.Degraded)
                    
                    .AddUrlGroup(new Uri(config["ApiResourceBaseUrls:SampleApi"]),
                                name: "External Api",
                                failureStatus: HealthStatus.Degraded)
                    
                    .AddSqlServer(connectionString: config[$"ConnectionStrings:{AppWebService.DefaultDb}"],
                                healthQuery: "SELECT 1;",
                                name: "SQL",
                                failureStatus: HealthStatus.Degraded,
                                tags: new string[] { "db", "sql", "sqlserver" });

                    services.AddHealthChecksUI()
                        .AddSqlServerStorage(config.GetConnectionString(AppWebService.DefaultDb));

        }
    }
}
