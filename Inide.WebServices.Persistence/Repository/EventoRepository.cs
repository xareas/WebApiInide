using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Text;
using Inide.WebServices.Persistence.Contracts;
using Serenity.Data;
using Serenity.Services;
using Entity = Inide.WebServices.Persistence.Domain.Evento;

namespace Inide.WebServices.Persistence.Repository
{
    public class EventoRepository : Repository<Entity>,IEventoRepository<Entity>
    {
        private static Entity.RowFields Fields =>Entity.Fields;
       
    }

       

}
