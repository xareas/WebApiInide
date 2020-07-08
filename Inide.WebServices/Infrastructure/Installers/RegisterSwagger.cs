using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Inide.WebServices.Contracts;
using Inide.WebServices.Infrastructure.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Inide.WebServices.Infrastructure.Installers
{
    internal class RegisterSwagger : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration config)
        {
            //Register Swagger
            //See: https://www.scottbrady91.com/Identity-Server/ASPNET-Core-Swagger-UI-Authorization-using-IdentityServer4
            services.AddSwaggerGen(opts =>
            {
                opts.SwaggerDoc("v1", 
                    new OpenApiInfo
                    {
                        Title = "WebServices INIDE-SEN API", 
                        Version = "v1",
                        Description = "Servicios Web de INIDE-SEN",
                        TermsOfService = null,

                        Contact = new OpenApiContact
                        {
                            Name = "Informatica INIDE",
                            Email = "inide@inide.gob.ni",
                            Url = new Uri("https://www.inide.gob.ni/"),
                        },
                        License = new OpenApiLicense
                        {
                            Name = "Uso de Licencia Restringida",
                            Url = new Uri("https://www.inide.gob.ni/api/license"),
                        }
                    });

                  var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"; 
                  var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile); 
                  opts.IncludeXmlComments(xmlPath);
                
                
                opts.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Scheme = "Bearer",
                    In = ParameterLocation.Header,
                    Description = "Introduce 'Bearer' espacio y luego su Token(JWT).",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                });

                opts.AddSecurityRequirement(new OpenApiSecurityRequirement() {
                    { new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme, 
                            Id = "Bearer"
                        }, Name = "Bearer",
                    }, new List<string>() } });
                
                opts.OperationFilter<SwaggerAuthorizeCheckOperationFilter>(); 
            });
        }
    }
}
