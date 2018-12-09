using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared.Classes;

namespace Difi.Sjalvdeklaration.wwwroot.Business.Interface
{
    public interface IApiHttpClient
    {
        Task<ApiResult<T>> Get<T>(string url);

        Task<T> Post<T>(string url, object jsonObject);

        Task<T> PostWithAuthorization<T>(string url, string authorizationType, string authorizationKey, StringContent stringContent);

        void LogError(Exception exception, object callParameter1 = null, object callParameter2 = null, [CallerMemberName] string callerFunctionName = null, [CallerFilePath] string callerFileName = null);
    }
}