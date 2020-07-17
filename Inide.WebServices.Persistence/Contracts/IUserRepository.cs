using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Inide.WebServices.Persistence.Common;
using Inide.WebServices.Persistence.Domain;
using Serenity.Data;

namespace Inide.WebServices.Persistence.Contracts
{
    public interface IUserRepository<T>: IRepository<T> where T : Row,IIdRow,INameRow,new()
    {
        public Task<UserDefinition> GetUserAsync(string userName);
    }

   
}
