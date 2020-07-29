using System.Text;
using Inide.WebServices.Contracts;
using IdentityServer4.AccessTokenValidation;
using Inide.WebServices.Constants;
using Inide.WebServices.Infrastructure.Configs;
using Inide.WebServices.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Inide.WebServices.Infrastructure.Installers
{
    internal class RegisterJwtAuthentication : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration config)
        {
            var appSettings = config.GetSection(AppConst.SettingsApp)
                                    .Get<AppSettings>();
            
            
            services.AddAuthentication()
              .AddJwtBearer(opts =>
              {
               opts.RequireHttpsMetadata = false;
               opts.SaveToken = true;
               opts.TokenValidationParameters = new TokenValidationParameters()
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,

                   ValidIssuer =appSettings.ValidIssuer,
                   ValidAudience = appSettings.ValidAudience,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.SecretKey))
               };

              });
        }

           //Setup JWT Authentication Handler with IdentityServer4
            //You should register the ApiName a.k.a Audience in your AuthServer
            //More info see: http://docs.identityserver.io/en/latest/topics/apis.html
            //For an example on how to build a simple Token server using IdentityServer4,
            //See: http://vmsdurano.com/apiboilerplate-and-identityserver4-access-control-for-apis/
          //  services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
         //       .AddIdentityServerAuthentication(options =>
         //       {
          //          options.Authority = config["ApiResourceBaseUrls:AuthServer"];
           //         options.RequireHttpsMetadata = false;
            //        options.ApiName = "inide.sen.api";
            //});
        

    }
}
