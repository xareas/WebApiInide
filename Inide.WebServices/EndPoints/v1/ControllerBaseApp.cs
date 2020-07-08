using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Inide.WebServices.Constants;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;

namespace Inide.WebServices.EndPoints.v1
{

    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiExplorerSettings(GroupName = "v1")]
    public abstract class ControllerBaseApp<T>: ControllerBase
    {
        protected readonly ILogger<T> Logger;
        protected readonly IMediator Mediator; 
       
        protected ControllerBaseApp(IMediator mediator, ILogger<T> logger)
        {
           
            Logger = logger;
            Mediator = mediator;
            SetCulture();
        }


        private static void SetCulture()
        {
           var culture = CultureInfo.GetCultureInfo(AppWebService.DefaultCulture);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }
    }
}
