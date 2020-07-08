using System.Data;
using System.Data.SqlClient;
using Inide.WebServices.Application.Handlers.Entidades;
using Inide.WebServices.Application.Handlers.Event;
using Inide.WebServices.Constants;
using Inide.WebServices.Contracts;
using Inide.WebServices.Infrastructure.Helpers;
using Inide.WebServices.Infrastructure.MiddleWare;
using Inide.WebServices.Persistence.Common;
using Inide.WebServices.Persistence.Domain;
using Inide.WebServices.Persistence.Repository;
using Inide.WebServices.Persistence.Contracts;
using Inide.WebServices.Security;
using Inide.WebServices.Services;
using Inide.WebServices.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inide.WebServices.Infrastructure.Installers
{
    internal class RegisterContractMappings : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration config)
        {
            //Registra los servicios
            services.AddTransient<ILogRecord, LogRecord>();

            //Registra la conexcion a la base de datos
            services.AddTransient<IDbConnection>(db => new SqlConnection(
                config.GetConnectionString(AppWebService.DefaultDb)));

            //Seguridad
            services.AddSingleton<IAuthenticationManager, AuthenticationManager>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddSingleton<IJwtHandler,JwtHandler>();
            services.AddTransient<TokenManagerMiddleware>();
            services.AddTransient<ITokenManager,TokenManager>();

            //Manager de Repositorios
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            
            //Entidades del Negocio
            //Manejo de la entidad de dominio evento
            services.AddTransient<IEventoRepository<Evento>, EventoRepository>();
            services.AddTransient<IEventoService, EventoService>();
            services.AddTransient<IEventManager, EventManager>();

            //Manajeo de la Entidad de Dominio , llamada entidad
            services.AddTransient<IEntidadRepository<Entidad>, EntidadRepository>();
            services.AddTransient<IEntidadService, EntidadService>();
            services.AddTransient<IEntidadManager, EntidadManager>();


        }
    }
}
