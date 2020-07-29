using System;
using System.Collections.Generic;
using System.Text;
using Inide.WebServices.Persistence.Common;
using Inide.WebServices.Persistence.Domain;
using Inide.WebServices.Persistence.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Inide.WebServices.Persistence.Repository
{
    public class RepositoryManager: IRepositoryManager
    {
        private readonly ILogger<RepositoryManager> _logger;
        private readonly IConfiguration _config;
        private IEventoRepository<Evento> _eventoRepository;
        private IEntidadRepository<Entidad> _entidadRepository;

        public RepositoryManager(IConfiguration config, ILogger<RepositoryManager> logger) 
        {
            _logger = logger;
            _config = config;
        }
     
        public IEventoRepository<Evento> EventoRepository
        {
            get
            {
                return _eventoRepository ??= new EventoRepository();
            }
        }

        public IEntidadRepository<Entidad> EntidadRepository {
            get
            {
                return _entidadRepository ??= new EntidadRepository();
            }
        }


    } //fin
}
