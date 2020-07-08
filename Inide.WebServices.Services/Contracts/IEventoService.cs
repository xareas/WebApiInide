using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Inide.WebServices.Persistence.Domain;
using Inide.WebServices.Persistence.Repository;
using Inide.WebServices.Persistence.Contracts;

namespace Inide.WebServices.Services.Contracts
{
    public interface IEventoService : IServiceBase,IEventoRepository<Evento>
    {
        //Aca definir tus propios metodos
        public Task<bool> ExecuteWithTransactionScope();


    }
}
