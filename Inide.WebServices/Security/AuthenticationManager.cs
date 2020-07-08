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
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace Inide.WebServices.Security
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IUserRepository _repository;
        private readonly AppSettings _settings;
        private readonly ISet<RefreshToken> _refreshTokens = new HashSet<RefreshToken>();
        private readonly IJwtHandler _jwtHandler;

        public AuthenticationManager(IOptions<AppSettings> settings, IJwtHandler jwtHandler, IUserRepository repository)
        {
            _repository = repository;
            _settings = settings.Value;
            _jwtHandler = jwtHandler;
        }

        public async Task<bool> ValidateUserAsync(string username, string password)
        {
            if (username.IsTrimmedEmpty() || string.IsNullOrEmpty(password))
                return false;
            username = username.TrimToEmpty();
            var user = await GetUserByNameAsync(username);

            bool ValidatePassword() => CalculateHash(password, user.PasswordSalt)
                    .Equals(user.PasswordHash, StringComparison.OrdinalIgnoreCase);

            return user != null && ValidatePassword();
        }

        public async Task<UserDefinition> GetUserByNameAsync(string userName)
        {
            return await _repository.GetUserAsync(userName);
        }

        public async Task<string> CreateTokenAsync(IUserDefinition user)
        {
             var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, user.UserId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtClaimsApp.Institucion, user.KeyDelegacion.ToString())
                };

               var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //Parametros del Token que se genera
                var tokenOptions = new JwtSecurityToken(_settings.ValidIssuer, _settings.ValidAudience,
                    claims, expires: DateTime.Now.AddMinutes(_settings.ExpiresMinutes), signingCredentials: credentials);
                return await Task.Run(() => new  JwtSecurityTokenHandler().WriteToken(tokenOptions) );
               
        }

        private static string CalculateHash(string password, string salt)
        {
            return SiteMembershipProvider.ComputeSHA512(password + salt);
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
