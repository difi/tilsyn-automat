using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Difi.Sjalvdeklaration.wwwroot.Business
{
    public class ApiHttpClient
    {
        private readonly IConfiguration configuration;

        private readonly HttpClient httpClient;

        public ApiHttpClient(IConfiguration configuration)
        {
            this.configuration = configuration;
            httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> Get<T>(string url)
        {
            httpClient.DefaultRequestHeaders.Remove("Authorization");

            var responseMessage = await httpClient.GetAsync(configuration["ApiBaseUrl"] + url);

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception(responseMessage.Content.ToString());
            }

            var responseData = responseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<T>(responseData);
        }

        public async Task<T> Post<T>(string url, object jsonObject)
        {
            httpClient.DefaultRequestHeaders.Remove("Authorization");

            var responseMessage = await httpClient.PostAsync(configuration["ApiBaseUrl"] + url, jsonObject.AsJson());

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception(responseMessage.Content.ToString());
            }

            var responseData = responseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<T>(responseData);
        }

        public async Task<T> PostWithAuthorization<T>(string url, string authorizationType, string authorizationKey, StringContent stringContent)
        {
            httpClient.DefaultRequestHeaders.Remove("Authorization");

            AddAuthorization(authorizationType, authorizationKey);

            var responseMessage = await httpClient.PostAsync(configuration["IdPorten:BaseUrl"] + url, stringContent);

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception(responseMessage.Content.ToString());
            }

            var responseData = responseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<T>(responseData);
        }

        public async Task<string> GetWithAuthorization<T>(string url, string authorizationType, string authorizationKey)
        {
            httpClient.DefaultRequestHeaders.Remove("Authorization");

            AddAuthorization(authorizationType, authorizationKey);

            var responseMessage = await httpClient.GetAsync(configuration["IdPorten:BaseUrl"] + url);

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception(responseMessage.Content.ToString());
            }

            var responseData = responseMessage.Content.ReadAsStringAsync().Result;

            return responseData;
        }

        private void AddAuthorization(string authorizationType, string authorizationKey)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", $"{authorizationType} {authorizationKey}");
        }
    }
}