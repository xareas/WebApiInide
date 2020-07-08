using System;
using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Inide.WebServices.Application.Handlers.Eventos;
using Inide.WebServices.Application.RequestModels;
using Inide.WebServices.Application.ResponseModels;
using Inide.WebServices.Infrastructure.Filters;
using Inide.WebServices.Persistence.Domain;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Serenity.Services;
using static Microsoft.AspNetCore.Http.StatusCodes;
using ILogger = Serilog.ILogger;

namespace Inide.WebServices.EndPoints.v1
{
    
    public class EventoController : ControllerBaseApp<EventoController>
    {
       
        private readonly IEventManager _commands;
       
        public EventoController(IEventManager eventManager,IMediator mediator, ILogger<EventoController> logger) : base(mediator, logger)
        {
            _commands = eventManager;
        }
       
    
        /// <summary>
        /// Obtiene todos los eventos registrados
        /// </summary>
        /// <returns>Retorna un objeto del tipo EventoQueryResponse</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EventoResponse>), Status200OK)]
        public async Task<IEnumerable<EventoResponse>> Get()
        {
           return await SendAsync(_commands.GetAll);
        }

        /// <summary>
        /// Obtiene la lista de eventos paginada
        /// </summary>
        /// <param name="urlQueryParameters">Paginacion</param>
        /// <returns>Retorna lista de eventos</returns>
        [Route("paged")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EventoResponse>), Status200OK)]
        public async Task<IEnumerable<EventoResponse>> Get([FromQuery] UrlQueryParameters urlQueryParameters)
        {
            var command = _commands.GetPaged;
            command.Parameters = urlQueryParameters;
            return await SendAsync(command);
        }

        /// <summary>
        /// Obtiene un evento en base al codigo del evento proporcionado
        /// </summary>
        /// <param name="codigo">Codigo del Evento</param>
        /// <returns>Retorna un EventoQueryResponse</returns>
        [Route("{codigo:long}")]
        [HttpGet]
        [ProducesResponseType(typeof(EventoResponse), Status200OK)]
        [ProducesResponseType(typeof(ApiResponse),Status404NotFound)]
        public async Task<EventoResponse> Get(long codigo)
        {
            var command = _commands.GetById;
            command.EntityId = codigo;
            
            return await SendAsync(command);
        }

       
       /// <summary>
       /// Contiene un listado de eventos filtrados
       /// </summary>
       /// <param name="categoria">Categoria de los eventos</param>
       /// <returns></returns>
        [HttpGet,Route("[action]/{categoria:long}")]
        [ProducesResponseType(typeof(ApiResponse), Status200OK)]
        public async Task<ListResponse<Evento>> GetItemList(long categoria)
        {
            var command = _commands.GetCategory;
            command.Categoria = categoria;
            
            return await SendAsync(command);
        }
        

        /// <summary>
        /// Crear un Evento
        /// </summary>
        /// <param name="createRequest">Evento a crear</param>
        /// <returns>un apiresponse</returns>
        /// <response code="201">Crea un nuevo evento</response>
        /// <response code="401">Acceso No Autorizado</response>
        /// <response code="403">Acceso Prohibido</response>
        /// <response code="400">Si el evento es nulo</response>
        /// <response code="422">Si los valores del evento son invalidos</response>
        [HttpPost,ValidationFilter]
        //[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        [ProducesResponseType(typeof(ApiResponse), Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse), Status403Forbidden)]
        [ProducesResponseType(typeof(ApiResponse), Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), Status422UnprocessableEntity)]
        public async Task<ApiResponse> Post([FromBody] CreateEventoRequest createRequest)
        {
            var command = _commands.Post;
            command.NewEntity = createRequest;
            
            return await SendAsync(command);

        }


        /// <summary>
        /// Actualizar un Evento
        /// </summary>
        /// <param name="id">codigo del evento</param>
        /// <param name="updateRequest">Evento actualizar</param>
        /// <returns></returns>
        [Route("{id:long}")]
        [HttpPut,ValidationFilter]
        [ProducesResponseType(typeof(ApiResponse), Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), Status422UnprocessableEntity)]
        public async Task<ApiResponse> Put(long id, [FromBody] UpdateEventoRequest updateRequest)
        {

           var command = _commands.Put;
           command.EntityId = id;
           command.EntityUpdate = updateRequest;

           return await SendAsync(command);

        }

        /// <summary>
        /// Quitar o borrar un elemento de la lista de eventos
        /// </summary>
        /// <param name="codigo">codigo del evento a borrar</param>
        /// <returns>un Apiresponse</returns>
        [Route("{codigo:long}")]
        [HttpDelete]
        [ProducesResponseType(typeof(ApiResponse), Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), Status404NotFound)]
        public async Task<ApiResponse> Delete(long codigo)
        {
            var command = _commands.Delete;
            command.EntityId = codigo;
           
            return await SendAsync(command);
        }


        
       
    } //fin clase
} //fin namesapce