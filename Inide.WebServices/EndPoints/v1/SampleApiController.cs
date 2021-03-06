﻿using Inide.WebServices.Contracts;
using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Inide.WebServices.Application.RequestModels;
using Inide.WebServices.Application.ResponseModels;
using Inide.WebServices.Persistence.Common;
using Inide.WebServices.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Serenity.Services;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace Inide.WebServices.EndPoints.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces("application/json",new []{"text/xml"})]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiExplorerSettings(GroupName = "v1")]
   public class SampleApiController : ControllerBase
    {
        private readonly ILogger<SampleApiController> _logger;
        private readonly IApiClient _sampleApiClient;
        private readonly IAuthenticationManager _auth;
        public SampleApiController(IAuthenticationManager auth,IApiClient sampleApiClient, ILogger<SampleApiController> logger) 
        {
            _sampleApiClient = sampleApiClient;
            _logger = logger;
            _auth = auth;
          
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse), Status200OK)]
        public async Task<ApiResponse> Get(long id)
        {

            var s = await _auth.ValidateUserAsync("admin", "joke2019%$");
            if (s)
            {
                var userDefinition = await _auth.GetUserDefinitionAsync("admin");
                if (userDefinition.IsActive==1)
                {
                    return new ApiResponse(){IsError = true,Message = "Cuenta Desactivada",StatusCode = 401};
                }
            }

            
            return new ApiResponse(await _sampleApiClient.GetDataAsync<SampleQueryResponse>($"/api/v1/sample/{id}"));
        }

       
        /// <summary>
        /// Crea un simple objeto de tipo request
        /// </summary>
        /// <param name="createRequest">El request a crear</param>
        /// <returns>Regresa un ApiResponse</returns>
        /// <response code="201">Si un nuevo item ha sido creado retorna esto</response>
        /// <response code="400">Si el item o elemento es nulo</response>
        /// <response code="422">Si el modelo es invalido</response>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse), Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), Status422UnprocessableEntity)]
        public async Task<ApiResponse> Post([FromBody] SampleRequest createRequest)
        {
            if (!ModelState.IsValid) { throw new ApiProblemDetailsException(ModelState); }

            return new ApiResponse(await _sampleApiClient.PostDataAsync<SampleQueryResponse, SampleRequest>("/api/v1/sample", createRequest));
        }
    }
}
