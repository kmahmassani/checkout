using Newtonsoft.Json;
using System;
using System.Net.Http;
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
            _baseUri = baseUri;
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            var response = await _client.GetAsync(_baseUri + uri);
            var objStr = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<T>(objStr);

            return obj;
        }

        public async Task<T> PostAsync<T>(object data, string uri)
        {
            var content = JsonConvert.SerializeObject(data);
            var httpContent = new StringContent(content);

            var response = await _client.PostAsync(_baseUri + uri, httpContent);
            var objStr = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<T>(objStr);

            return obj;
        }               
    }
}
