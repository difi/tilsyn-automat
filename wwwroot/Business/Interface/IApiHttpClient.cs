using System.Net.Http;
using System.Threading.Tasks;

namespace Difi.Sjalvdeklaration.wwwroot.Business
{
    public interface IApiHttpClient
    {
        Task<T> Get<T>(string url);

        Task<string> GetWithAuthorization<T>(string url, string authorizationType, string authorizationKey);

        Task<T> Post<T>(string url, object jsonObject);

        Task<T> PostWithAuthorization<T>(string url, string authorizationType, string authorizationKey, StringContent stringContent);
    }
}