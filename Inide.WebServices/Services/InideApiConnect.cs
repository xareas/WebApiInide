using Inide.WebServices.Contracts;
using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using Inide.WebServices.Constants;
using Microsoft.Extensions.Logging;
using AutoWrapper.Server;

namespace Inide.WebServices.Services
{
    public class InideApiConnect : IApiConnect
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<InideApiConnect> _logger;
        public InideApiConnect(HttpClient httpClient, ILogger<InideApiConnect> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<SampleResponse> PostDataAsync<SampleResponse, SampleRequest>(string endPoint, SampleRequest dto)
        {
            var content = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, HttpContentMediaTypes.JSON);
            var httpResponse = await _httpClient.PostAsync(endPoint, content);

            if (!httpResponse.IsSuccessStatusCode)
            {
                _logger.Log(LogLevel.Warning, $"[{httpResponse.StatusCode}] Se produjo un error al llamar al api.");
                return default;
            }

            var jsonString = await httpResponse.Content.ReadAsStringAsync();
            var data = Unwrapper.Unwrap<SampleResponse>(jsonString);

            return data;
        }

        public async Task<SampleResponse> GetDataAsync<SampleResponse>(string endPoint)
        {
            var httpResponse = await _httpClient.GetAsync(endPoint);

            if (!httpResponse.IsSuccessStatusCode)
            {
                _logger.Log(LogLevel.Warning, $"[{httpResponse.StatusCode}] Ocurrio un error al llamar aun api externo.");
                return default;
            }

            var jsonString = await httpResponse.Content.ReadAsStringAsync();
            var data = Unwrapper.Unwrap<SampleResponse>(jsonString);

            return data;
        }

    }
}
