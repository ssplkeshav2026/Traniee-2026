using EmployeeTaskManagementSystemMVC.IServices;
using EmployeeTaskManagementSystemMVC.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using System.Security.Claims;

namespace EmployeeTaskManagementSystemMVC.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<AuthResponseVM?> LoginAsync(LoginVM model)
        {
            var client = _httpClientFactory.CreateClient("TaskApi");
            var response = await client.PostAsJsonAsync("api/auth/login", model);

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<AuthResponseVM>();
        }

        public async Task<bool> RegisterAsync(RegisterVM model)
        {
            var client = _httpClientFactory.CreateClient("TaskApi");

            var response = await client.PostAsJsonAsync(
                "api/auth/register",
                model);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage =
                    await response.Content.ReadAsStringAsync();

                throw new Exception(errorMessage);
            }

            return true;
        }

        public void SaveTokens(AuthResponseVM token)
        {
            var session = _httpContextAccessor.HttpContext.Session;

            session.SetString("AccessToken", token.AccessToken);
            session.SetString("RefreshToken", token.RefreshToken);
        }

        public string? GetAccessToken()
        {
            return _httpContextAccessor.HttpContext?.Session.GetString("AccessToken");
        }

        public string? GetRefreshToken()
        {
            return _httpContextAccessor.HttpContext?.Session.GetString("RefreshToken");
        }

        public void ClearTokens()
        {
            _httpContextAccessor.HttpContext?.Session.Clear();
        }

        public bool IsLoggedIn()
        {
            return !string.IsNullOrEmpty(GetAccessToken());
        }

        public async Task<bool> RefreshAccessTokenAsync()
        {
            var refreshToken = GetRefreshToken();

            if (string.IsNullOrEmpty(refreshToken))
            {
                ClearTokens();
                return false;
            }

            var client = _httpClientFactory.CreateClient("TaskApi");

            var response = await client.PostAsJsonAsync("api/auth/refresh-token",
                new
                {
                    refreshToken = refreshToken
                });

            if (!response.IsSuccessStatusCode)
            {
                ClearTokens();
                return false;
            }

            var newToken = await response.Content.ReadFromJsonAsync<AuthResponseVM>();

            if (newToken == null)
            {
                ClearTokens();
                return false;
            }

            SaveTokens(newToken);

            return true;
        }

        public async Task<bool> LogoutAsync()
        {
            var refreshToken = GetRefreshToken();

            var client = _httpClientFactory.CreateClient("TaskApi");

            if (!string.IsNullOrEmpty(refreshToken))
            {
                await client.PostAsJsonAsync("api/auth/logout",
                    new
                    {
                        refreshToken = refreshToken
                    });
            }

            ClearTokens();

            return true;
        }
        public string? GetRole()
        {
            var token = GetAccessToken();

            if (string.IsNullOrEmpty(token))
                return null;

            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.ReadJwtToken(token);

            return jwt.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role || x.Type == "role")?.Value;
        }
    }
}