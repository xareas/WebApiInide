using Inide.WebServices.Contracts;
using IdentityModel.Client;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;


namespace Inide.WebServices.Infrastructure.Handlers
{
    public class ProtectedApiBearerTokenHandler : DelegatingHandler
    {
        private readonly IAuthServerConnect _authServerConnect;

        public ProtectedApiBearerTokenHandler(IAuthServerConnect authServerConnect)
        {
            _authServerConnect = authServerConnect;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // acceso al token de seguridad
            var accessToken = await _authServerConnect.RequestClientCredentialsTokenAsync();

            // establecer el Authentication Header
            request.SetBearerToken(accessToken);

            // llamar al handler del token
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
