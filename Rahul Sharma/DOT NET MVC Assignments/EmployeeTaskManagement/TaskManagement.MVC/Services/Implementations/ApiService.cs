

using System.Net.Http.Headers;
using System.Text;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TaskManagement.MVC.Helpers;
using TaskManagement.MVC.Services.Interfaces;
using TaskManagement.MVC.ViewModels.Auth;

namespace TaskManagement.MVC.Services.Implementations
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ITokenStorageService _tokenStorageService;

        public ApiService(
            HttpClient httpClient,
            IOptions<ApiSettings> apiSettings,
            ITokenStorageService tokenStorageService)
        {
            _httpClient = httpClient;
            _tokenStorageService = tokenStorageService;
            _httpClient.BaseAddress = new Uri(apiSettings.Value.BaseUrl);
        }

        public async Task<TResponse?> GetAsync<TResponse>(string endpoint)
        {
            await AddAuthorizationHeaderAsync();

            var response = await _httpClient.GetAsync(endpoint);
            return await HandleResponse<TResponse>(response);
        }

        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            if (!endpoint.Contains("auth/login") && !endpoint.Contains("auth/register"))
            {
                await AddAuthorizationHeaderAsync();
            }

            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endpoint, content);
            return await HandleResponse<TResponse>(response);
        }

        public async Task<TResponse?> PutAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            await AddAuthorizationHeaderAsync();

            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(endpoint, content);
            return await HandleResponse<TResponse>(response);
        }

        public async Task<TResponse?> PatchAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            await AddAuthorizationHeaderAsync();

            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PatchAsync(endpoint, content);
            return await HandleResponse<TResponse>(response);
        }

        public async Task<bool> DeleteAsync(string endpoint)
        {
            await AddAuthorizationHeaderAsync();

            var response = await _httpClient.DeleteAsync(endpoint);
            return response.IsSuccessStatusCode;
        }

        private async Task AddAuthorizationHeaderAsync()
        {
            if (_tokenStorageService.IsAccessTokenExpired())
            {
                var refreshed = await RefreshAccessTokenAsync();

                if (!refreshed)
                {
                    throw new UnauthorizedAccessException("Session expired. Please login again.");
                }
            }

            var token = _tokenStorageService.GetAccessToken();

            _httpClient.DefaultRequestHeaders.Authorization = null;

            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }
        }

        private async Task<bool> RefreshAccessTokenAsync()
        {
            var refreshToken = _tokenStorageService.GetRefreshToken();

            if (string.IsNullOrEmpty(refreshToken))
                return false;

            var request = new RefreshTokenRequestViewModel
            {
                RefreshToken = refreshToken
            };

            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Authorization = null;

            var response = await _httpClient.PostAsync("auth/refresh-token", content);

            if (!response.IsSuccessStatusCode)
            {
                _tokenStorageService.ClearTokens();
                return false;
            }

            var responseBody = await response.Content.ReadAsStringAsync();

            var tokenResponse = JsonConvert.DeserializeObject<AuthResponseViewModel>(responseBody);

            if (tokenResponse == null)
                return false;

            _tokenStorageService.StoreTokens(
                tokenResponse.AccessToken,
                tokenResponse.RefreshToken,
                tokenResponse.ExpiresIn);

            return true;
        }

        private static async Task<TResponse?> HandleResponse<TResponse>(HttpResponseMessage response)
        {
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(
                    $"API Error: {(int)response.StatusCode} {response.StatusCode} - {responseBody}");
            }

            return JsonConvert.DeserializeObject<TResponse>(responseBody);
     
}
    }
}