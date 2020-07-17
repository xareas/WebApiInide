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


            //Desabilitamos badrequest para devolver unprocesable entity - 117
            services.Configure<ApiBehaviorOptions>(opt => { opt.SuppressModelStateInvalidFilter = true; });
        }
    }
}
