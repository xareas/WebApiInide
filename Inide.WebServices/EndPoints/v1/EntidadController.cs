using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Inide.WebServices.Application.Events;
using Inide.WebServices.Application.ResponseModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Inide.WebServices.Application.Handlers.Entidades;
using Inide.WebServices.Infrastructure.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace Inide.WebServices.EndPoints.v1
{
    
    public class EntidadController : ControllerBaseApp<EntidadController>
    {

        private readonly IEntidadManager _commands;
        
        public EntidadController(IEntidadManager manager, IMediator mediator, ILogger<EntidadController> logger) : base(mediator, logger)
        {
            _commands = manager;
        }

        /// <summary>
        /// Obtiene un Listado de Entidades con sus codigos
        /// </summary>
        /// <returns></returns>
        [HttpGet,Authorize(),SetThreadCurrentPrincipal]
        public async Task<IEnumerable<EntidadResponse>> Get()
        {
            //await Mediator.Publish(new TransaccionEvent("query"));
            return await SendAsync(_commands.GetAll);
        }

        /// <summary>
        /// Obtiene un Listado de Elementos de la Entidaad
        /// </summary>
        /// <param name="id">Codigo de la entidad</param>
        /// <returns></returns>
        [Route("{id:long}/Elementos"),HttpGet,SetThreadCurrentPrincipal]
        public async Task<IEnumerable<ElementoResponse>> Elementos(long id)
        {
            return await SendAsync(_commands.GetElements);
        }

       /// <summary>
       /// Obtiene el listado de los grupos de los elementos
       /// </summary>
       /// <returns>Listado de Grupos</returns>
        [Route("Grupos"),HttpGet,SetThreadCurrentPrincipal]
        public async Task<IEnumerable<GrupoEntidadResponse>> Grupos()
        {
            return await SendAsync(_commands.GetGrupos);
        }

       
    }
}
