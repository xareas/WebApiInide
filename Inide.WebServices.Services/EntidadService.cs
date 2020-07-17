using System;
using System.Collections.Generic;
using System.Text;
using Inide.WebServices.Persistence.Repository;
using Inide.WebServices.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Inide.WebServices.Services
{
    public class EntidadService : EntidadRepository,IEntidadService
    {
        private readonly IConfiguration _config;
        private readonly ILogger _logger;


        public EntidadService(IConfiguration config,ILogger<EventoService> logger) 
        {
            _config = config;
            _logger = logger;
        }

       
    }
}
