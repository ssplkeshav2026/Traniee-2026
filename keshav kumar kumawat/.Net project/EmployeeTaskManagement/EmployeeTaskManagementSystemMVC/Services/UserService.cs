using EmployeeTaskManagementSystemMVC.Helpers;
using EmployeeTaskManagementSystemMVC.IServices;
using EmployeeTaskManagementSystemMVC.ViewModels;
using System.Net.Http.Headers;

namespace EmployeeTaskManagementSystemMVC.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IAuthService _authService;

        public UserService(IHttpClientFactory httpClientFactory,IAuthService authService)
        {
            _httpClientFactory = httpClientFactory;
            _authService = authService;
        }

        private async Task<HttpClient?> CreateClientWithTokenAsync()
        {
            var client = _httpClientFactory.CreateClient("TaskApi");

            var accessToken = _authService.GetAccessToken();

            if (string.IsNullOrEmpty(accessToken))
                return null;

            if (TokenHelper.IsTokenExpired(accessToken))
            {
                var refreshed = await _authService.RefreshAccessTokenAsync();

                if (!refreshed)
                    return null;

                accessToken = _authService.GetAccessToken();
            }

            client.DefaultRequestHeaders.Authorization =new AuthenticationHeaderValue("Bearer", accessToken);

            return client;
        }

        public async Task<List<UserVM>> GetUsersAsync()
        {
            var client = await CreateClientWithTokenAsync();

            if (client == null)
                return new List<UserVM>();

            var response = await client.GetAsync("api/users");

            if (!response.IsSuccessStatusCode)
                return new List<UserVM>();

            var users = await response.Content.ReadFromJsonAsync<List<UserVM>>();

            return users ?? new List<UserVM>();
        }

        public async Task<UserVM?> GetUserByIdAsync(string id)
        {
            var client = await CreateClientWithTokenAsync();

            if (client == null)
                return null;

            var response = await client.GetAsync($"api/users/{id}");

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<UserVM>();
        }

        public async Task<bool> ChangeUserRoleAsync(string userId, string role)
        {
            var client = await CreateClientWithTokenAsync();

            if (client == null)
                return false;

            var response = await client.PutAsync($"api/users/{userId}/role?role={role}",null);

            return response.IsSuccessStatusCode;
        }
    }
}