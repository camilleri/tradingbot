using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HttpClientLogic
{
    public class CryptoCompareHttpClient : IHttpClient
    {
        private HttpClient HttpClient => _httpClient.Value;

        private static readonly Lazy<HttpClient> _httpClient = new Lazy<HttpClient>(() => BuildHttpClient());

        private static HttpClient BuildHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://min-api.cryptocompare.com");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        public async Task<T> GetAsync<T>(string path) where T : class
        {
            using(var response = await HttpClient.GetAsync(path))
            {
                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }       
    }
}