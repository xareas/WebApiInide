﻿using System.Net;
using System.Threading.Tasks;
using Inide.WebServices.Contracts;
using Microsoft.AspNetCore.Http;

namespace Inide.WebServices.Infrastructure.MiddleWare
{
    public class TokenManagerMiddleware : IMiddleware
    {
        private readonly ITokenManager _tokenManager;

        public TokenManagerMiddleware(ITokenManager tokenManager)
        {
            _tokenManager = tokenManager;
        }
        
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (await _tokenManager.IsCurrentActiveToken())
            {
                await next(context);
                
                return;
            }
           
            context.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
        }
    }
}