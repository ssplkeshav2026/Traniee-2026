using EmpTaskManagementMVC.IService;
using EmpTaskManagementMVC.ViewModel.Users;
using System.Net.Http.Headers;
using static Microsoft.CodeAnalysis.CSharp.SyntaxTokenParser;

namespace EmpTaskManagementMVC.Services
{
    public class MvcUsersService : IMvcUsersService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMvcAuthService _mvcAuthService;

        public MvcUsersService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor, IMvcAuthService mvcAuthService)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _mvcAuthService = mvcAuthService;
        }

        private async Task GetAccessToken()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            var accessToken = session.GetString("AccessToken");
            var refreshToken = session.GetString("RefreshToken");

            if (string.IsNullOrEmpty(accessToken))
            {
                return;
            }
            if (string.IsNullOrEmpty(refreshToken))
            {
                return;
            }
            var accessTokenExpiryTime = await _mvcAuthService.GetAccessTokenExpireTime(accessToken);
            {

                if (accessTokenExpiryTime <= DateTime.UtcNow)
                {
                    try
                    {
                        var newToken = await _mvcAuthService.RefreshTokenAsync(refreshToken);
                        Console.WriteLine("OLD TOKEN: " + accessToken);
                        Console.WriteLine("NEW TOKEN: " + newToken.AccessToken);
                        session.SetString("AccessToken", newToken.AccessToken);

                        session.SetString("RefreshToken", newToken.RefreshToken);

                        accessToken = newToken.AccessToken;
                    }
                    catch (Exception)
                    {
                        session.Clear();
                    }
                }
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }
        }

        public async Task<List<UsersViewModel>> GetAllUsersAsync()
        {
           await GetAccessToken();

            var response = await _httpClient.GetFromJsonAsync<List<UsersViewModel>>("/api/users/getAll");
            if(response == null)
            {
                return new List<UsersViewModel>();
            }
            return response; 
        }


        public async Task<UsersViewModel> GetUserByIdAsync(string id)
        {
            await GetAccessToken();

            var response = await _httpClient.GetFromJsonAsync<UsersViewModel>($"/api/users/{id}");

            if (response == null)
            {
                return new UsersViewModel();
            }
            return response;
        }

        public async Task<string> DeleteUserAsync(string id)
        {
            await GetAccessToken();

            var response = await _httpClient.DeleteAsync($"/api/users/{id}");
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> UpdateUserAsync(UpdateUserViewModel model)
        {
            await GetAccessToken();

            var response = await _httpClient.PutAsJsonAsync("/api/users/edit", model);
            var result = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                return "Error: " + result;
            }

            return result;
        }
    }
}
