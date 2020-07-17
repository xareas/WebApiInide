using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Inide.WebServices.Persistence.Contracts;

namespace Inide.WebServices.Contracts
{
    public interface ITokenManager
    {
        Task<bool> IsCurrentActiveToken();
        Task DeactivateCurrentAsync();
        Task<bool> IsActiveAsync(string token);
        Task DeactivateAsync(string token);

        Task<string> GenerateAccessToken(IUserDefinition user);
        Task<string> GenerateRefreshToken();
        Task<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token);


    }
}