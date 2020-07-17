using Inide.WebServices.Constants;
using Inide.WebServices.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inide.WebServices.Infrastructure.Installers
{
    internal class RegisterCors : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration config)
        {
            //Configura CORS para permitir cualquier origin, header and method. 
            //Para Mas informacion ver:
            //https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-3.0
            services.AddCors(options =>
            {
                options.AddPolicy(AppConst.AllowAllPolicy,
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });
        }
    }
}
