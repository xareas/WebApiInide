using Inide.WebServices.Contracts;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inide.WebServices.Infrastructure.Installers
{
    internal class RegisterRequestRateLimiter : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration config)
        {
            // cargar configuracion de  appsettings.json
            services.AddOptions();
            // almacenamiento en cache de reglas
            services.AddMemoryCache();

            //Cargar configuracion appsettings.json
            services.Configure<IpRateLimitOptions>(config.GetSection("IpRateLimiting"));

            // Contador y reglas
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();

            // https://github.com/aspnet/Hosting/issues/793
            // Registramos a  IHttpContextAccessor no es registrado por defecto.
            // para que podamos tener acceso al contexto del http.
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Configuracion
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        }
    }
}
