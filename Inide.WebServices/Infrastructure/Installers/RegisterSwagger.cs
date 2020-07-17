using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Inide.WebServices.Contracts;
using Inide.WebServices.Infrastructure.Filters;
using Inide.WebServices.Infrastructure.Handlers;
using Microsoft.AspNetCore.Mvc;
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
                var urlTerms = config["AppSettings:Swagger:UrlTerms"];
                var urlSite = config["AppSettings:Swagger:UrlSite"];
                var urlLicense = config["AppSettings:Swagger:UrlSite"];
                var emailSite = config["AppSettings:Swagger:Email"];
                const string Schema = "Bearer";

                opts.SwaggerDoc("v1", 
                    new OpenApiInfo
                    {
                        Title = "WebServices INIDE-SEN API", 
                        Version = "v1",
                        Description = "Servicios Web de INIDE-SEN",
                        TermsOfService = new Uri(urlTerms),

                        Contact = new OpenApiContact
                        {
                            Name = "Informatica INIDE",
                            Email = emailSite,
                            Url = new Uri(urlSite),
                        },
                        License = new OpenApiLicense
                        {
                            Name = "Uso de Licencia Restringida",
                            Url = new Uri(urlLicense),
                        }
                    });

                  var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"; 
                  var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile); 
                  opts.IncludeXmlComments(xmlPath);
                
                opts.AddSecurityDefinition(Schema, new OpenApiSecurityScheme
                {
                    Scheme = Schema,
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
                            Id = Schema
                        }, Name = Schema,
                    }, new List<string>() } });
                
               
            });
        }
    }
}
