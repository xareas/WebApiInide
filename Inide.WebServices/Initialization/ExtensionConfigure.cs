using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoWrapper;
using Inide.WebServices.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.SwaggerUI;

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

        public static IApplicationBuilder UseConfigureSwagger(this IApplicationBuilder app,IConfiguration config)
        {
            //Obtenemos el theme
            var theme = config.GetSection(AppConst.SettingsTheme).Get<string>();
            theme += ".css";


            //Habilitar Swagger and SwaggerUI
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "swagger/{documentName}/swagger.json";
            });

            
            app.UseSwaggerUI(opts =>
            {
                opts.RoutePrefix = "swagger";
                opts.DocumentTitle = "Documento WebServices";
                opts.DocExpansion(DocExpansion.None);
                opts.InjectStylesheet(theme);
                opts.InjectJavascript("swagger.js");
                opts.SwaggerEndpoint("/swagger/v1/swagger.json", "WebServices INISE-SEN v1");
            });

            app.UseStaticFiles();
            
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
