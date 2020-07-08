using System;
using System.Threading.Tasks;
using Inide.WebServices.Persistence.Repository;
using Inide.WebServices.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Inide.WebServices.Services
{
    public class EventoService : EventoRepository,IEventoService
    {
        private IConfiguration _config;
        private ILogger _logger;


        public EventoService(IConfiguration config,ILogger<EventoService> logger) 
        {
            _config = config;
            _logger = logger;
        }

        public async Task<bool> ExecuteWithTransactionScope()
        {
            return await Task.Run(() => true);
        }

        IConfiguration IServiceBase.Config
        {
            get => _config;
            set => _config = value;
        }

        ILogger IServiceBase.Logger
        {
            get => _logger;
            set => _logger = value;
        }
    }
}
