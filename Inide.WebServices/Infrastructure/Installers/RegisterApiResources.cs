using Inide.WebServices.Constants;
using Inide.WebServices.Contracts;
using Inide.WebServices.Infrastructure.Configs;
using Inide.WebServices.Infrastructure.Handlers;
using Inide.WebServices.Services;
using IdentityModel.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Inide.WebServices.Infrastructure.Installers
{
    internal class RegisterApiResources : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration config)
        {
            var policyConfigs = new HttpClientPolicyConfiguration();
            config.Bind("HttpClientPolicies", policyConfigs);

            var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(policyConfigs.RetryTimeoutInSeconds));

            //Configuracion de Polly para la resistencia y manejo de fallas transitorias
            //que permite a los desarrolladores expresar políticas como Retry,
            //Circuit Breaker, Timeout, Bulkhead Isolation y Fallback de manera fluida y segura.
            var retryPolicy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(r => r.StatusCode == HttpStatusCode.NotFound)
                .WaitAndRetryAsync(policyConfigs.RetryCount, _ => TimeSpan.FromMilliseconds(policyConfigs.RetryDelayInMs));

            var circuitBreakerPolicy = HttpPolicyExtensions
               .HandleTransientHttpError()
               .CircuitBreakerAsync(policyConfigs.MaxAttemptBeforeBreak, TimeSpan.FromSeconds(policyConfigs.BreakDurationInSeconds));

            var noOpPolicy = Policy.NoOpAsync().AsAsyncPolicy<HttpResponseMessage>();

            
              //Registrar el Handler para Bearer Token. 
             // services.AddTransient<ProtectedApiBearerTokenHandler>();
            
             //Info: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-3.0
             services.AddHttpClient<IApiClient, InideApiClient>(client =>
            {
                client.BaseAddress = new Uri(config["AppSettings:ApiBaseUrls:InideApi"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(HttpContentMediaTypes.JSON));
            })
            .SetHandlerLifetime(TimeSpan.FromMinutes(policyConfigs.HandlerTimeoutInMinutes))
            .AddHttpMessageHandler<ProtectedApiBearerTokenHandler>()
            .AddPolicyHandler(request => request.Method == HttpMethod.Get ? retryPolicy : noOpPolicy)
            .AddPolicyHandler(timeoutPolicy)
            .AddPolicyHandler(circuitBreakerPolicy);

            //Seguridad en AuthService 
         // services.AddHttpClient<IAuthServerConnect, AuthServerConnect>();
           
            // Cache
         //   services.AddSingleton<IDiscoveryCache>(r =>
          //  {
           //     var factory = r.GetRequiredService<IHttpClientFactory>();
            //    return new DiscoveryCache(config["ApiResourceBaseUrls:AuthServer"], () => factory.CreateClient());
           // });
        }
    }
}


