using Inide.WebServices.Contracts;
using Inide.WebServices.Infrastructure.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using Inide.WebServices.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Inide.WebServices.Infrastructure.Installers
{
    internal class RegisterHealthChecks : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration config)
        {
            return;
              var url = new Uri(config["ApiResourceBaseUrls:InideApi"]).ToString();
            //Register HealthChecks and UI
            services.AddHealthChecks()
                .AddCheck("Sitio Inide", new PingHealthCheck("www.inide.gob.ni", 200))
                .AddCheck("Sitio Api", new PingHealthCheck(url,timeout:200))
              //  .AddCheck("Google Ping", new PingHealthCheck("www.google.com", TIMEOUT))
                .AddUrlGroup(new Uri(config["ApiResourceBaseUrls:InideApi"]),
                                name: "Api Inide",
                                failureStatus: HealthStatus.Degraded)
                    
                    .AddSqlServer(connectionString: config[$"ConnectionStrings:{AppConst.DefaultDb}"],
                                healthQuery: "SELECT 1;",
                                name: "SQL",
                                failureStatus: HealthStatus.Degraded,
                                tags: new string[] { "db", "sql", "sqlserver" });

            services.AddHealthChecksUI(opt =>
            {  }).AddSqlServerStorage(config.GetConnectionString(AppConst.DefaultDb), op =>
            {
             });

        }
    }
}
