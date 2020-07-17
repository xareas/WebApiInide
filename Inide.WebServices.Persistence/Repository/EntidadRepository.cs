using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper.Contrib.Extensions;
using Inide.WebServices.Persistence.Contracts;
using Serenity.Data;
using MyRow = Inide.WebServices.Persistence.Domain.Entidad;
namespace Inide.WebServices.Persistence.Repository
{
    public class EntidadRepository : Repository<MyRow>,IEntidadRepository<MyRow>
    {
        private static MyRow.RowFields fld =>MyRow.Fields;


        
    }
}
