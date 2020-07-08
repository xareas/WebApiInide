using System.Threading.Tasks;

namespace Inide.WebServices.Contracts
{
    public interface IAuthServerConnect
    {
        Task<string> RequestClientCredentialsTokenAsync();
    }
}
