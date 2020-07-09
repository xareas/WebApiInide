﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoWrapper.Wrappers;
using Inide.WebServices.Application.RequestModels;
using Inide.WebServices.Contracts;
using Inide.WebServices.Infrastructure.Filters;
using Inide.WebServices.Security;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Inide.WebServices.EndPoints.v1
{

   [Route("authentication")]
   public class AuthenticationController: ControllerBaseApp<AuthenticationController>
   {
        private readonly IAuthenticationManager _authentication;

        public AuthenticationController(IAuthenticationManager manager,IMediator mediator, ILogger<AuthenticationController> logger) : base(mediator, logger)
        {
            _authentication = manager;
        }

        /// <summary>
        /// Permite Generar un Json Web Token
        /// </summary>
        /// <param name="user">Usuario y Clave</param>
        ///  <returns>Token del usuario</returns>
        /// <response code="200">Crea un Token JWT(Json Web Token)</response>
        /// <response code="401">Acceso No Autorizado</response>
        /// <response code="403">Acceso Prohibido</response>
        /// <response code="422">Entidad no procesable, usuario y clave invalidos</response>
        [HttpPost("api/login")]
        [AllowAnonymous,ValidationFilter]
       // [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IActionResult> Authenticate([FromBody] UserAuthenticationRequest user)
        {
            if (!await _authentication.ValidateUserAsync(user.UserName, user.Password)) 
                return Unauthorized();

            var userDefinition = await _authentication.GetUserByNameAsync(user.UserName);
            return Ok(new {Token = await _authentication.CreateTokenAsync(userDefinition)});

        }

       

    }
}
