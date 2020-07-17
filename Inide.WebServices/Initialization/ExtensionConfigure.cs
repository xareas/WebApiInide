using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoWrapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Inide.WebServices.Initialization
{
    public static class ExtensionConfigure
    {

        public static IApplicationBuilder UseConfigureWraper(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Habilitando AutoWrapper.Core el manejador de excepciones y response
            app.UseApiResponseAndExceptionWrapper(new AutoWrapperOptions { 
                IsDebug = env.IsDevelopment(),
                IsApiOnly = false,
                WrapWhenApiPathStartsWith = "/api",
                UseCamelCaseNamingStrategy = true,
                ApiVersion = "v1.0",
                ShowStatusCode = true,
                ShowApiVersion = true,
                UseApiProblemDetailsException = true });
            return app;
        }

        public static IApplicationBuilder UseConfigureSwagger(this IApplicationBuilder app)
        {
            //Habilitar Swagger and SwaggerUI
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebServices INISE-SEN v1");
            });

            return app;

        }


        public static IApplicationBuilder UseConfigureEndPoints(this IApplicationBuilder app)
        {
            //Microsoft Sugiere que no debemos usar enrutado basado en convencion
            //por tanto el enrutado estara basado en atributos
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }

        public static IApplicationBuilder UseConfigureHsts(this IApplicationBuilder app,IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseHsts();
            }

            return app;
        }


    }
}
