using System;
using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Inide.WebServices.Application.Handlers.Eventos;
using Inide.WebServices.Application.RequestModels;
using Inide.WebServices.Application.ResponseModels;
using Inide.WebServices.Infrastructure.Filters;
using Inide.WebServices.Persistence.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;


namespace Inide.WebServices.EndPoints.v1
{
    [ApiExplorerSettings(GroupName = "v1")]
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
        [HttpGet,SetThreadCurrentPrincipal]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IEnumerable<EventoResponse>> Get()

        {
         return await SendAsync(_commands.GetAll);
        }

        /// <summary>
        /// Obtiene la lista de eventos paginada
        /// </summary>
        /// <param name="urlQueryParameters">Paginacion</param>
        /// <returns>Retorna lista de eventos</returns>
        [Route("paged"),HttpGet,SetThreadCurrentPrincipal]
         public async Task<IEnumerable<EventoResponse>> Get([FromQuery] UrlQueryParameters urlQueryParameters)
        {
            Logger.LogInformation("Cargando los datos");
            var command = _commands.GetPaged;
            command.Parameters = urlQueryParameters;
            return await SendAsync(command);
        }

        /// <summary>
        /// Obtiene un evento en base al codigo del evento proporcionado
        /// </summary>
        /// <param name="codigo">Codigo del Evento</param>
        /// <returns>Retorna un EventoQueryResponse</returns>
        /// <response code="200">Solicitud Procesada Correctamente</response>
        /// <response code="401">Acceso No Autorizado</response>
        /// <response code="403">Acceso Prohibido</response>
        /// <response code="400">Solicitud es Invalida</response>
        /// <response code="404">Elemento no Encontrado</response>
        /// <response code="422">Solicitud no contiene los valores correctos</response>
        [Route("{codigo:long}"),HttpGet,SetThreadCurrentPrincipal]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Find))]
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
       /// <response code="200">Solicitud Procesada Correctamente</response>
       /// <response code="401">Acceso No Autorizado</response>
       /// <response code="403">Acceso Prohibido</response>
       /// <response code="400">Solicitud es Invalida</response>
       /// <response code="404">Elemento no Encontrado</response>
       /// <response code="422">Solicitud no contiene los valores correctos</response>
        [HttpGet,Route("[action]/{categoria:long}"),SetThreadCurrentPrincipal]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Find))]
        public async Task<IEnumerable<Evento>> GetFilter(long categoria)
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
        /// <response code="201">Solicitud Procesada Correctamente</response>
        /// <response code="401">Acceso No Autorizado</response>
        /// <response code="403">Acceso Prohibido</response>
        /// <response code="400">Solicitud es Invalida</response>
        /// <response code="404">Elemento no Encontrado</response>
        /// <response code="422">Solicitud no contiene los valores correctos</response>
        [HttpPost,ValidationFilter]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Create))]
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
        /// <response code="204">Solicitud Procesada Correctamente</response>
        /// <response code="401">Acceso No Autorizado</response>
        /// <response code="403">Acceso Prohibido</response>
        /// <response code="400">Solicitud es Invalida</response>
        /// <response code="404">Elemento no Encontrado</response>
        /// <response code="422">Solicitud no contiene los valores correctos</response>
       [Route("{id:long}"),HttpPut,ValidationFilter]
       [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Update))]
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
        /// <response code="200">Solicitud Procesada Correctamente</response>
        /// <response code="401">Acceso No Autorizado</response>
        /// <response code="403">Acceso Prohibido</response>
        /// <response code="400">Solicitud es Invalida</response>
        /// <response code="404">Elemento no Encontrado</response>
        /// <response code="422">Solicitud no contiene los valores correctos</response>
        [Route("{codigo:long}"),HttpDelete]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<ApiResponse> Delete(long codigo)
        {
            var command = _commands.Delete;
            command.EntityId = codigo;
           
            return await SendAsync(command);
        }


        
       
    } //fin clase
} //fin namesapce