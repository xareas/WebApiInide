using System.Threading.Tasks;

namespace Inide.WebServices.Contracts
{
    public interface IApiClient
    {
        Task<TResponse> PostDataAsync<TResponse, TRequest>(string endPoint, TRequest request);
        Task<TResponse> GetDataAsync<TResponse>(string endPoint);
    }
}
