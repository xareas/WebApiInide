using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Text;
using Inide.WebServices.Persistence.Contracts;
using Serenity.Data;
using Serenity.Services;
using MyRow = Inide.WebServices.Persistence.Domain.Evento;

namespace Inide.WebServices.Persistence.Repository
{
    public class EventoRepository : Repository<MyRow>,IEventoRepository<MyRow>
    {
        private static MyRow.RowFields fld =>MyRow.Fields;
       
    }

       

}
