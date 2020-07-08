using Inide.WebServices.Contracts;
using FluentValidation;
using Inide.WebServices.Application.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inide.WebServices.Infrastructure.Installers
{
    internal class RegisterModelValidators : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            //Aca registramos los modelos y sus respectivas clases de validacion
            services.AddTransient<IValidator<CreateEventoRequest>, CreateEventoRequestValidator>();
            services.AddTransient<IValidator<UpdateEventoRequest>, UpdateEventoRequestValidator>();
            services.AddTransient<IValidator<UserAuthenticationRequest>, UserAuthenticationRequestValidator>();


            //Desahabilitar el estado de validacion que trae ASP.NET Core
            services.Configure<ApiBehaviorOptions>(opt => { opt.SuppressModelStateInvalidFilter = true; });
        }
    }
}
