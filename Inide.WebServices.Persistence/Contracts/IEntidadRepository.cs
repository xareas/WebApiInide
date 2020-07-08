using System;
using System.Collections.Generic;
using System.Text;
using Inide.WebServices.Persistence.Common;
using Serenity.Data;

namespace Inide.WebServices.Persistence.Contracts
{
    public interface IEntidadRepository<T>: IRepository<T> where T : Row,IIdRow,INameRow,new()
    {
    }
}
