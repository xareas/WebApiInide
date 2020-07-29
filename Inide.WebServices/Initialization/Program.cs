using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using Serilog;

namespace Inide.WebServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = CreateHostBuilder(args).Build();
            var logger = builder.Services.GetService<ILogger<Program>>();
            try
            {
                logger.LogInformation("Iniciando Servicios Web Inide ");
                logger.LogDebug("Kestrel http://*:5000/swagger/index.html");
                builder.Run();
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, "Se Produjo un error fatal");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureHostConfiguration(configBuilder =>
                    configBuilder.AddJsonFile("appsettings.Logs.json", true, true)
                )
               .UseSerilog((hostingContext, log) =>
                {

                    var config = hostingContext.Configuration;
                    log.ReadFrom.Configuration(config)
                        .Enrich.FromLogContext()
                        .WriteTo.File($"logs/WebServiceLog-.txt",rollingInterval: RollingInterval.Day);

                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
