using Inide.WebServices.Mapping;
using Inide.WebServices.Infrastructure.Extensions;
using AspNetCoreRateLimit;
using AutoMapper;
using AutoWrapper;
using FluentValidation.AspNetCore;
using HealthChecks.UI.Client;
using Inide.WebServices.Constants;
using Inide.WebServices.Infrastructure.Middleware;
using Inide.WebServices.Infrastructure.MiddleWare;
using Inide.WebServices.Initialization;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Inide.WebServices
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        

        // Agregamos los servicios al contenedor.
        public void ConfigureServices(IServiceCollection services)
        {
            
            //Registramos aplicando el patron Fluent Interface
            services.AddServicesRegister(Configuration)
                    .AddContextHttpRegister()
                    .AddMemoryCacheRegister()
                    .AddAutoMapperRegister()
                    .AddControllersRegister();
        
        }

        //  Usa este metodo para configurar el HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseConfigureWraper(env);
            app.UseConfigureHsts(env);
            app.UseHttpsRedirection();
            //Permite el manejo de versiones del api
            app.UseApiVersioning();
            app.UseConfigureSwagger(this.Configuration);
            //Serilog
            app.UseSerilogRequestLogging();
            //Habilitando la Libreria AspNetCoreRateLimit
            app.UseIpRateLimiting();
            app.UseRouting();
            //Habilitando CORS
            app.UseCors(AppConst.AllowAllPolicy);
            //Reenviar encabezados 
            app.UseForwardedHeaders(new ForwardedHeadersOptions {ForwardedHeaders = ForwardedHeaders.All});
            //realizar autentificacion en cada solicitud
             app.UseAuthentication();
            //Agregar autorizacion al api
            app.UseAuthorization();
            app.UseResponseCaching();
            //todo:EndPoint middleware para monitoreo servicios pendiente
            //app.UseRequestResponseLogging();
            app.UseTokenManager();
            //Configuracion de los Endpoints
            app.UseConfigureEndPoints();
        }
    }
}
