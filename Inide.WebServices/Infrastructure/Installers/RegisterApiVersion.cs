using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inide.WebServices.Constants;
using Inide.WebServices.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inide.WebServices.Infrastructure.Installers
{
    public class RegisterApiVersion : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddApiVersioning(opt =>
            {
                opt.ReportApiVersions = true;
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = new ApiVersion(1,0);
                opt.ApiVersionReader = new HeaderApiVersionReader(AppConst.ApiHeader);
            });
        }
    }
}
