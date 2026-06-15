using EmpTaskManagementMVC.IService;
using EmpTaskManagementMVC.ViewModel;
using System.IdentityModel.Tokens.Jwt;

namespace EmpTaskManagementMVC.Services
{
    public class MvcAuthService : IMvcAuthService
    {
        private readonly HttpClient _httpClient;

        public MvcAuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> RegisterAsync(RegisterViewModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Auth/register", model);
            return response.IsSuccessStatusCode;
        }

        public async Task<LoginTokenResponseViewModel> LoginAsync(LoginViewModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Auth/login", model);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Login Failed");
            }
            var result = await response.Content.ReadFromJsonAsync<LoginTokenResponseViewModel>();
            return result;
        }
        public async Task<LoginTokenResponseViewModel> RefreshTokenAsync(string refreshToken)
        {
            var token = new RefreshTokenViewModel
            {
                RefreshToken = refreshToken
            };
            var response = await _httpClient.PostAsJsonAsync("/api/Auth/refreshToken", token);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Refresh Token Failed");
            }
            response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<LoginTokenResponseViewModel>();

        }
       public async  Task<string> LogoutAsync(string refreshToken)
        {
            var token = new RefreshTokenViewModel
            {
                RefreshToken = refreshToken
            };
            var response = await _httpClient.PostAsJsonAsync("/api/Auth/logout",token);
            if (!response.IsSuccessStatusCode)
            {
                return "logout Failed";
            }
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<DateTime?> GetAccessTokenExpireTime(string accessToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(accessToken);
            var expiry = jwtToken.Payload.Expiration;
            if (expiry.HasValue)
            {
                var dateTime = DateTimeOffset.FromUnixTimeSeconds(expiry.Value).UtcDateTime;
                return dateTime;
            }
            return null;
        }
    }
    }
    

