using Newtonsoft.Json;
using System.Text;
using TaskManagementSystemMVC.ViewModel;

namespace TaskManagementSystemMVC.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<(bool success, string accessToken, string refreshToken, string error)>
            LoginAsync(LoginViewModel model)
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var content = new StringContent(
                JsonConvert.SerializeObject(new
                {
                    email = model.Email,
                    password = model.Password
                }),
                Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/Auth/login", content);

            if (!response.IsSuccessStatusCode)
                return (false, "", "", "Invalid email or password");

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeAnonymousType(json,
                new { accessToken = "", refreshToken = "", expiresIn = 0 });

            return (true, result!.accessToken, result.refreshToken, "");
        }

        public async Task<(bool success, string error)>
            RegisterAsync(RegisterViewModel model)
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var content = new StringContent(
                JsonConvert.SerializeObject(new
                {
                    firstName = model.FirstName,
                    lastName = model.LastName,
                    email = model.Email,
                    password = model.Password
                }),
                Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/Auth/register", content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                return (false, error);
            }

            return (true, "");
        }
    }
}
