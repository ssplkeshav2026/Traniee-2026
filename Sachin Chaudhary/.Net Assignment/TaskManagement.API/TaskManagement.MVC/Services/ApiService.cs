using System.Net.Http;
using System.Threading.Tasks;
using TaskManagement.MVC.Interfaces;

namespace TaskManagement.MVC.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await _httpClient.GetAsync(url);
        }
        public async Task<HttpResponseMessage> PostAsync(
                  string url,
                  HttpContent content)
        {
            return await _httpClient.PostAsync(
                url,
                content);
        }

        public async Task<HttpResponseMessage> PutAsync(
            string url,
            HttpContent content)
        {
            return await _httpClient.PutAsync(
                url,
                content);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            return await _httpClient.DeleteAsync(url);
        }
    }
}