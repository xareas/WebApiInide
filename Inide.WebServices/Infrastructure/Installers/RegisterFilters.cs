using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inide.WebServices.Contracts;
using Inide.WebServices.Infrastructure.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inide.WebServices.Infrastructure.Installers
{
    public class RegisterFilters : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<ValidationFilterAttribute>();

        }
    }
}
