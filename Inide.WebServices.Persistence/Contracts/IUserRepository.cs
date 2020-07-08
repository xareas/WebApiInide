using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Inide.WebServices.Persistence.Domain;

namespace Inide.WebServices.Persistence.Contracts
{
    public interface IUserRepository
    {
        public Task<UserDefinition> GetUserAsync(string userName);
    }

   
}
