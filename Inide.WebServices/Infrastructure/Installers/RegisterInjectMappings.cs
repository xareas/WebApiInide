using System.Data;
using System.Data.SqlClient;
using System.Security.Principal;
using Inide.WebServices.Application.Handlers.Entidades;
using Inide.WebServices.Application.Handlers.Eventos;
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
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serenity.Data;

namespace Inide.WebServices.Infrastructure.Installers
{

    //El registro de un servicio en el contenedor DI con el
    //método AddTransientdevuelve un nuevo objeto cada vez que se inyecta el tipo.
    //con el método AddSingleton, se devuelve el mismo objeto con cada inyección.
    //El método AddScoped está en algún punto intermedio. En el mismo ámbito,
    //se devuelve la misma instancia. En un ámbito diferente,
    //se crea una nueva instancia. Un ambito con las aplicaciones ASP.NET Core
    //es una solicitud HTTP crea un nuevo alcance. Inyectando servicios basados
    //​​en la solicitud HTTP, con servicios con ámbito se devuelve el mismo objeto.
    internal sealed class RegisterInjectMappings : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration config)
        {

            //myService = ActivatorUtilities.CreateInstance<Service>(serviceProvider, new OtherServiceB())

            //Registra los servicios
            services.AddTransient<ILogRecord, LogRecord>();
            
            //Registra la conexcion a la base de datos
            services.AddTransient<IDbConnection>(db => 
                new SqlConnection(config.GetConnectionString(AppConst.DefaultDb)));
            
            services.AddTransient<IUnitOfWork>(db => 
                new UnitOfWork(new SqlConnection(config.GetConnectionString(AppConst.DefaultDb))));
            
            services.AddTransient<IDbConnectionFactory>(e 
                => new SqlDbFactory(config.GetConnectionString(AppConst.DefaultDb)));

            //Principal Claims
            services.AddTransient<IPrincipal>(
                provider => provider.GetService<IHttpContextAccessor>().HttpContext.User);
            
            //Seguridad
            services.AddSingleton<IAuthenticationManager, AuthenticationManager>();
            services.AddSingleton<IJwtHandler,JwtHandler>();
            services.AddTransient<TokenManagerMiddleware>();
            services.AddSingleton<ITokenManager,TokenManager>();

            //Manager de Repositorios
            services.AddSingleton<IRepositoryManager, RepositoryManager>();
         
            //Usuarios sigue el patron DDD
            services.AddTransient<IUserRepository<UserDefinition>, UserRepository>();
            services.AddTransient<IUserService, UserService>();


            //Entidades del Negocio
            //Manejo de la entidad de dominio evento
            services.AddScoped<IEventoRepository<Evento>, EventoRepository>();
            services.AddScoped<IEventoService, EventoService>();
            services.AddSingleton<IEventManager, EventManager>();

           
            //Manajeo de la Entidad de Dominio , llamada entidad
            services.AddScoped<IEntidadRepository<Entidad>, EntidadRepository>();
            services.AddScoped<IEntidadService, EntidadService>();
            services.AddScoped<IGrupoEntidadRepository<GrupoEntidad>, GrupoEntidadRepository>();
            services.AddScoped<IGrupoEntidadService, GrupoEntidadService>();
            services.AddScoped<IElementoRepository<Elemento>, ElementoRepository>();
            services.AddScoped<IElementoService, ElementoService>();
            services.AddSingleton<IEntidadManager, EntidadManager>();



        }
    }
}
