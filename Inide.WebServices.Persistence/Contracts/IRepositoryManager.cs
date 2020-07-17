using System;
using System.Collections.Generic;
using System.Text;
using Inide.WebServices.Persistence.Domain;
using Inide.WebServices.Persistence.Repository;

namespace Inide.WebServices.Persistence.Contracts
{
    public interface IRepositoryManager
    {
        public IEventoRepository<Evento> EventoRepository { get; }
        public IEntidadRepository<Entidad> EntidadRepository { get; }

    }
}
