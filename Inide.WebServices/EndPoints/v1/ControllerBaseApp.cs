using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Inide.WebServices.Constants;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;

namespace Inide.WebServices.EndPoints.v1
{

   
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces("application/json",new []{"text/xml"})]
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

        /// <summary>
        /// Cultura predeterminada del API
        /// </summary>
        private  void SetCulture()
        {
            var culture = CultureInfo.GetCultureInfo(AppConst.DefaultCulture);
           
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

           
        }

        /// <summary>
        /// Enviar comandos a MediatR
        /// </summary>
        /// <typeparam name="TResult">Resultados</typeparam>
        /// <param name="command">Comando</param>
        /// <returns></returns>
        protected async Task<TResult> SendAsync<TResult>(IRequest<TResult> command)
        {
            return await Mediator.Send(command);
        }
        
        

    }
}
