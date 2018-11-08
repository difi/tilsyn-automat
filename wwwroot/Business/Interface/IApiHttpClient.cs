using System.Net.Http;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared.Classes;

namespace Difi.Sjalvdeklaration.wwwroot.Business.Interface
{
    public interface IApiHttpClient
    {
        Task<ApiResult<T>> Get<T>(string url);

        Task<T> Post<T>(string url, object jsonObject);

        Task<T> PostWithAuthorization<T>(string url, string authorizationType, string authorizationKey, StringContent stringContent);
    }
}