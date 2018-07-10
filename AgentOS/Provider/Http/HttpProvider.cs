using System.Net.Http;
using System.Text;

namespace AgentOS.Provider.Http
{
    public class HttpProvider
    {

        private readonly string _urlBase;
        private readonly HttpClient _httpClient;


        public HttpProvider(string urlBase, HttpClient httpClient)
        {
            _urlBase = urlBase;
            _httpClient = httpClient ?? new HttpClient();
            _httpClient.BaseAddress = new System.Uri(_urlBase);
        }

        public string SendPostJson<T>(string url, T body)
        {
            //var content = new StringContent(JsonConvert.SerializeObject(), Encoding.UTF8, "application/json");
            //var result = _httpClient.PostAsync(url, content).Result;
            return null;
        }

    }
}
