using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Inide.WebServices.Constants;
using Inide.WebServices.Contracts;
using Inide.WebServices.Infrastructure.Configs;
using Inide.WebServices.Persistence.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;


namespace Inide.WebServices.Security
{
    public class TokenManager : ITokenManager
    {
        private readonly IDistributedCache _cache;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppSettings _jwtOptions;

        public TokenManager(IDistributedCache cache,
                IHttpContextAccessor httpContextAccessor,
                IOptions<AppSettings> jwtOptions
            )
        {
            _cache = cache;
            _httpContextAccessor = httpContextAccessor;
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<bool> IsCurrentActiveToken() => await IsActiveAsync(GetCurrentAsync());

        public async Task DeactivateCurrentAsync() => await DeactivateAsync(GetCurrentAsync());

        public async Task<bool> IsActiveAsync(string token) => await _cache.GetStringAsync(GetKey(token)) == null;

        public async Task DeactivateAsync(string token) => await _cache.SetStringAsync(GetKey(token),
                " ", new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(_jwtOptions.ExpiresMinutes)
                });

       private string GetCurrentAsync()
        {
            var authorizationHeader = _httpContextAccessor
                .HttpContext.Request.Headers["authorization"];

            return authorizationHeader == StringValues.Empty
                ? string.Empty
                : authorizationHeader.Single().Split(" ").Last();
        }
        
        private static string GetKey(string token) => $"tokens:{token}:desactivado";


        /// <summary>
        /// Generar el token de acceso
        /// </summary>
        /// <param name="user">perfil del usuario</param>
        /// <returns></returns>
        public async Task<string> GenerateAccessToken(IUserDefinition user)
        {
            var role = user.KeyInstitucion ==  _jwtOptions.KeyMaster ? AppConst.Claims.Roles.Internal : AppConst.Claims.Roles.Public;

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("inst", user.KeyInstitucion.ToString()),
                new Claim(ClaimTypes.Role, role)
            };
          
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Generamos el Token de refresco
            var refreshToken = GenerateRefreshToken();
            var expireTime = DateTime.Now.AddDays(2);
            

            //Parametros del Token que se genera
            var tokenOptions = new JwtSecurityToken(_jwtOptions.ValidIssuer, _jwtOptions.ValidAudience,
                claims, expires: DateTime.Now.AddMinutes(_jwtOptions.ExpiresMinutes), signingCredentials: credentials);
            return await Task.Run(() => new  JwtSecurityTokenHandler().WriteToken(tokenOptions) );

        }

        /// <summary>
        /// Generar el token de refrescamiento
        /// </summary>
        /// <returns></returns>
        public async Task<string> GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return await Task.Run(() => Convert.ToBase64String(randomNumber));
        }

        /// <summary>
        /// El principal
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters =  new TokenValidationParameters
            {
                ValidateAudience = false, 
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
                ValidateLifetime = false //No importa la fecha de expiracion
            };
 
            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Token Invalido");
 
            return await Task.Run(()=>principal);
        }




    }
}