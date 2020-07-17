using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inide.WebServices.Persistence.Contracts;
using Inide.WebServices.Persistence.Domain;

namespace Inide.WebServices.Contracts
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUserAsync(string username, string password);
        Task<UserDefinition> GetUserDefinitionAsync(string userName);
        Task<string> GetTokenAuthenticateAsync(IUserDefinition user);
    }
}
