using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper.Contrib.Extensions;
using Inide.WebServices.Persistence.Contracts;
using Serenity.Data;
using Entity = Inide.WebServices.Persistence.Domain.Entidad;
namespace Inide.WebServices.Persistence.Repository
{
    public class EntidadRepository : Repository<Entity>,IEntidadRepository<Entity>
    {
        private static Entity.RowFields Fields =>Entity.Fields;


        
    }
}
