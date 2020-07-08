using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inide.WebServices.Infrastructure.MiddleWare;
using Microsoft.AspNetCore.Builder;

namespace Inide.WebServices.Infrastructure.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestResponseLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestResponseLoggingMiddleware>();
        }

        public static IApplicationBuilder UseTokenManager(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TokenManagerMiddleware>();
        }

    }
}
