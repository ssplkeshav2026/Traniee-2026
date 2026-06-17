using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace TaskManagementSystemMVC.Helper
{
    public class ApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApiService(IHttpClientFactory httpClientFactory,IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        // Creates HttpClient and attaches Bearer token automatically
        private HttpClient CreateClient()
        {
            var client = _httpClientFactory.CreateClient("ApiClient");

            // Read access token from cookie
            var token = _httpContextAccessor.HttpContext?.Request.Cookies["access_token"];

            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }

            return client;
        }

        public async Task<T?> GetAsync<T>(string endpoint)
        {
            var client = CreateClient();
            var response = await client.GetAsync(endpoint);

            if (!response.IsSuccessStatusCode)  
                return default;

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }

        public async Task<T?> PostAsync<T>(string endpoint, object data)
        {
            var client = CreateClient();
            var content = BuildContent(data);

            var response = await client.PostAsync(endpoint, content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception(error);
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }

        public async Task PostAsync(string endpoint, object data)
        {
            var client = CreateClient();
            var content = BuildContent(data);
            await client.PostAsync(endpoint, content);
        }

        public async Task<bool> PutAsync(string endpoint, object data)
        {
            var client = CreateClient();
            var content = BuildContent(data);

            var response = await client.PutAsync(endpoint, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string endpoint)
        {
            var client = CreateClient();
            var response = await client.DeleteAsync(endpoint);
            return response.IsSuccessStatusCode;
        }

        private static StringContent BuildContent(object data)
        {
            return new StringContent(
                JsonConvert.SerializeObject(data),
                Encoding.UTF8,
                "application/json");
        }
    }
}
