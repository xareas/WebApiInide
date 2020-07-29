using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Inide.WebServices.Persistence.Domain;
using Inide.WebServices.Persistence.Repository;
using Inide.WebServices.Persistence.Contracts;
using Entity = Inide.WebServices.Persistence.Domain.Evento;

namespace Inide.WebServices.Services.Contracts
{
    public interface IEventoService : IServiceBase,IEventoRepository<Entity>
    {
        //Aca definir tus propios metodos
        public Task<bool> ExecuteWithTransactionScope();

    }
}
