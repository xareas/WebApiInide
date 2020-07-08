﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inide.WebServices.Application.ResponseModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Inide.WebServices.Application.Handlers.Entidades;
using Microsoft.Extensions.Logging;
using static Microsoft.AspNetCore.Http.StatusCodes;
using ILogger = Serilog.ILogger;

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
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EntidadResponse>), Status200OK)]
        public async Task<IEnumerable<EntidadResponse>> Get()
        {
            return await Mediator.Send(_commands.GetAll);
        }

        /// <summary>
        /// Obtiene un Listado de Elementos de la Entidaad
        /// </summary>
        /// <param name="id">Codigo de la entidad</param>
        /// <returns></returns>
        [Route("{id:long}/Elementos")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EntidadResponse>), Status200OK)]
        public async Task<IEnumerable<EntidadResponse>> GetElementos(long id)
        {
            return await Mediator.Send(_commands.GetAll);
        }


       
    }
}
