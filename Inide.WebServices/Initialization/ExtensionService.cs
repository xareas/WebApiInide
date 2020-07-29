using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using Inide.WebServices.Infrastructure.Extensions;
using Inide.WebServices.Mapping;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inide.WebServices.Initialization
{
    public static class FluentConfigure
    {
        //Mediante reflexion cargamos la configuracion de servicios
        //es decir todas las clases que implementan la interfaz IServerRegistration
        //todas estas clases estan en la carpeta Installares
        public static IServiceCollection AddServicesRegister(this IServiceCollection services,IConfiguration config)
        {
             services.AddServicesInAssembly(config);
             return services;
        }

        public static IServiceCollection AddContextHttpRegister(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            return services;
        }
        public static IServiceCollection AddMemoryCacheRegister(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            return services;
        }

        public static IServiceCollection AddAutoMapperRegister(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfileConfiguration));
            return services;
        }

        //Registramos MVC/Web API, NewtonsoftJson y agregamos soporte para FluentValidation
        public static IServiceCollection AddControllersRegister(this IServiceCollection services)
        {
            services.AddControllers(opts =>
                {
                    opts.RespectBrowserAcceptHeader = true;
                    opts.ReturnHttpNotAcceptable = true;
                })
                .AddNewtonsoftJson(ops => { ops.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore; })
                .AddXmlDataContractSerializerFormatters()
                .AddFluentValidation(fv => { fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false; });
            return services;
        }



    }
}
