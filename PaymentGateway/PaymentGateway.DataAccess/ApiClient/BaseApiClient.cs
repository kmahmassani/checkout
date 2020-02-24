using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.DataAccess.ApiClient
{
    public class BaseApiClient
    {
        private readonly HttpClient _client;
        private readonly string _baseUri;

        public BaseApiClient(HttpClient client, string baseUri)
        {
            _client = client;
            _client.BaseAddress = new Uri(baseUri);
            _baseUri = baseUri;
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            var response = await _client.GetAsync(uri);
            var objStr = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<T>(objStr);

            return obj;
        }

        /// <summary>
        /// Posts request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="uri"></param>
        /// <exception cref="HttpRequestException">Thrown when remote server cannot be reached</exception>
        /// <returns>T</returns>
        public async Task<T> PostAsync<T>(object data, string uri)
        {
            var content = JsonConvert.SerializeObject(data);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            

            var response = await _client.PostAsync(uri, httpContent);
            var objStr = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<T>(objStr);

            return obj;
        }               
    }
}
