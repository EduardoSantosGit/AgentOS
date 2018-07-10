using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AgentOS.Provider.Http
{
    public class HttpProvider
    {
        private readonly string _urlBase;
        private readonly HttpClient _httpClient;

        public HttpProvider(string urlBase, HttpClient httpClient = null)
        {
            _urlBase = urlBase;
            _httpClient = httpClient ?? new HttpClient();
            _httpClient.BaseAddress = new System.Uri(_urlBase);
        }

        public async Task<string> SendPostJson<T>(string url, T body)
        {
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync(url, content);

            if (result.StatusCode != System.Net.HttpStatusCode.OK)
                return "ERROR";

            return "OK";
        }

    }
}
