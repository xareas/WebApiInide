using System;
using System.Collections.Generic;
using System.Text;
using Inide.WebServices.Persistence.Contracts;
using MyRow = Inide.WebServices.Persistence.Domain.Entidad;
namespace Inide.WebServices.Persistence.Repository
{
    public class EntidadRepository : Repository<MyRow>,IEntidadRepository<MyRow>
    {
        private static MyRow.RowFields fld =>MyRow.Fields;
    }
}
