using System.Collections.Generic;
using System.Security.Claims;
using Inide.WebServices.Security;


namespace Inide.WebServices.Contracts
{
    public interface IJwtHandler
    {
        JsonWebToken Create(string username);
    }
}