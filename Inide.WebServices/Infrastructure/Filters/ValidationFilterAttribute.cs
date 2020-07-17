using System;
using System.Collections.Generic;
using System.Linq;
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
}
