using Inide.WebServices.Infrastructure.Configs;
using Inide.WebServices.Infrastructure.Extensions;
using AspNetCoreRateLimit;
using AutoMapper;
using AutoWrapper;
using FluentValidation.AspNetCore;
using HealthChecks.UI.Client;
using Inide.WebServices.Constants;
using Inide.WebServices.Infrastructure.Middleware;
using Inide.WebServices.Infrastructure.MiddleWare;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Inide.WebServices
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Agregamos los servicios al contenedor.
        public void ConfigureServices(IServiceCollection services)
        {

            //Mediante reflexion cargamos la configuracion de servicios de installers
            services.AddServicesInAssembly(Configuration);

            //Registramos MVC/Web API, NewtonsoftJson y agregamos soporte para FluentValidation
            services.AddControllers(opts =>
                {
                    opts.RespectBrowserAcceptHeader = true;
                    opts.ReturnHttpNotAcceptable = true;
                })
                .AddNewtonsoftJson(ops => { ops.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore; })
                .AddXmlDataContractSerializerFormatters()
                .AddFluentValidation(fv => { fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false; });
            
            services.AddDistributedMemoryCache();
            //Register Automapper
            services.AddAutoMapper(typeof(MappingProfileConfiguration));

        }

        //  Usa este metodo para configurar el HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days.
                // ver https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            
            //Habilitar Swagger and SwaggerUI
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebServices INISE-SEN v1");
            });

            
            //Habilitando HealthChecks and UI
            app.UseHealthChecks("/selfcheck", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            }).UseHealthChecksUI(setup =>
            {
                setup.AddCustomStylesheet($"{env.ContentRootPath}/Infrastructure/HealthChecks/Ux/branding.css");
            });
            
            
            //Habilitando AutoWrapper.Core
            app.UseApiResponseAndExceptionWrapper(new AutoWrapperOptions { IsDebug = true, UseApiProblemDetailsException = true });

            //Habilitando AspNetCoreRateLimit
            app.UseIpRateLimiting();

            app.UseRouting();

            //Habilitando CORS
            app.UseCors(AppWebService.AllowAllPolicy);
            
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

            app.UseEndpoints(endpoints =>
            {
               endpoints.MapControllers();
            });

        }
    }
}
