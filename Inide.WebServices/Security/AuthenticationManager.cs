using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Inide.WebServices.Constants;
using Inide.WebServices.Contracts;
using Inide.WebServices.Infrastructure.Configs;
using Inide.WebServices.Infrastructure.Helpers;
using Inide.WebServices.Persistence.Contracts;
using Inide.WebServices.Persistence.Domain;
using Inide.WebServices.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Inide.WebServices.Security
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IUserService _service;
        private readonly AppSettings _settings;
        private readonly ISet<RefreshToken> _refreshTokens = new HashSet<RefreshToken>();
        private readonly IJwtHandler _jwtHandler;
        private readonly ITokenManager _tokenManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private UserDefinition CurrentUserDefinition { get; set; }
        private  HttpContext Context => _httpContextAccessor.HttpContext;

        public AuthenticationManager(IOptions<AppSettings> settings,ITokenManager tokenManager, 
            IJwtHandler jwtHandler, IUserService service,IHttpContextAccessor httpContextAccessor)
        {
            _service = service;
            _settings = settings.Value;
            _jwtHandler = jwtHandler;
            _tokenManager = tokenManager;
        }

        public async Task<bool> ValidateUserAsync(string username, string password)
        {
            if (username.IsTrimmedEmpty() || string.IsNullOrEmpty(password))
                return false;
            username = username.TrimToEmpty();
            var user = await GetUserDefinitionAsync((username));

            bool ValidatePassword() => CalculateHash(password, user.PasswordSalt)
                    .Equals(user.PasswordHash, StringComparison.OrdinalIgnoreCase);

            return user != null && ValidatePassword();
        }

        public async Task<UserDefinition> GetUserDefinitionAsync(string userName)
        {
            if (CurrentUserDefinition != null) return CurrentUserDefinition;
            
            CurrentUserDefinition = await _service.GetUserAsync(userName);
            return CurrentUserDefinition;

        }

        public async Task<bool> IsAuthenticated()
        {
           return await Task.Run(() => Context.User.Identity.IsAuthenticated);
        }

        public async Task<UserDefinition> CurrentUser()
        {
            if (CurrentUserDefinition != null) return CurrentUserDefinition;
            if (!await IsAuthenticated()) return null;
            return await GetUserDefinitionAsync(Context.User.Identity.Name);
        }

        public async Task<string> GetTokenAuthenticateAsync(IUserDefinition user)
        {
            return  await _tokenManager.GenerateAccessToken(user);
        }

        private static string CalculateHash(string password, string salt)
        {
            var hash = SiteMembershipProvider.ComputeSHA512(password + salt);
            return hash;
        }
        
        public void RevokeRefreshToken(string token)
        {
            var refreshToken = GetRefreshToken(token);
            if (refreshToken == null)
            {
                throw new Exception("Refresh Token No fue encontrado.");
            }
            if (refreshToken.Revoked)
            {
                throw new Exception("Refresh Token fue revocado.");
            }
            refreshToken.Revoked = true;
        }

        public JsonWebToken RefreshAccessToken(string token)
        {
            var refreshToken = GetRefreshToken(token);
            if (refreshToken == null)
            {
                throw new Exception("Refresh Token no fue encontrado.");
            }
            if (refreshToken.Revoked)
            {
                throw new Exception("Refresh Token fue revocado");
            }
            var jwt = _jwtHandler.Create(refreshToken.Username);;
            jwt.RefreshToken = refreshToken.Token;

            return jwt;
        }
        
        private RefreshToken GetRefreshToken(string token)
            => _refreshTokens.SingleOrDefault(x => x.Token == token);



    } //fin
}//fin
