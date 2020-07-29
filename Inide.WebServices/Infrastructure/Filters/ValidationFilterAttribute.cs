using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Inide.WebServices.Infrastructure.Filters
{
    public class ValidationFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
               throw new ApiProblemDetailsException(context.ModelState);
            }
        }
    }

    /// <summary>
    /// Hacking debido aun problema de Thread.CurrentPrincipal en asp.net core 3.1
    /// siempre devuelve nulo
    /// https://github.com/dotnet/runtime/issues/29151
    /// </summary>
    public class SetThreadCurrentPrincipalAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User == null) return;

            if (context.HttpContext.User.Identity.IsAuthenticated)
                Thread.CurrentPrincipal = context.HttpContext.User;
        }
    }

}
