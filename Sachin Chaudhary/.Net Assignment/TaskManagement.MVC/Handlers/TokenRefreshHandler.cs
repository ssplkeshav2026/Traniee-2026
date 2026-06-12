using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using TaskManagement.MVC.Interfaces;
using TaskManagement.MVC.ViewModels;

namespace TaskManagement.MVC.Handlers
{
    public class TokenRefreshHandler : DelegatingHandler
    {
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        public TokenRefreshHandler(ITokenService tokenService, IConfiguration configuration)
        {
            _tokenService = tokenService;
            _configuration = configuration;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var accessToken = await _tokenService.GetAccessToken();

            if (!string.IsNullOrEmpty(accessToken))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

            var response = await base.SendAsync(request, cancellationToken);

            // Trigger automatic background token rotation if API intercepts a 401 Unauthorized status
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var refreshToken = await _tokenService.GetRefreshToken();

                if (string.IsNullOrEmpty(refreshToken))
                {
                    return response;
                }

                using var client = new HttpClient();

                // Read configuration string and clean up leading/trailing whitespaces
                var baseUrl = (_configuration["ApiSettings:BaseUrl"] ?? "http://localhost:5072").Trim();

                // Safely remove trailing slash to prevent double slash format issues like "localhost:5072//api"
                if (baseUrl.EndsWith("/"))
                {
                    baseUrl = baseUrl.TrimEnd('/');
                }

                // Construct a clean, absolute URI path string
                var refreshUrl = $"{baseUrl}/api/auth/refresh-token";

                var refreshRequest = new { RefreshToken = refreshToken };
                var json = JsonConvert.SerializeObject(refreshRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Execute background refresh call using the safely parsed URI string
                var refreshResponse = await client.PostAsync(refreshUrl, content, cancellationToken);

                if (refreshResponse.IsSuccessStatusCode)
                {
                    var data = await refreshResponse.Content.ReadAsStringAsync();
                    var tokens = JsonConvert.DeserializeObject<AuthResponseViewModel>(data);

                    if (tokens != null)
                    {
                        await _tokenService.SetTokens(tokens.AccessToken, tokens.RefreshToken);

                        // Resubmit original HTTP request using the newly rotated authentication token
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokens.AccessToken);
                        return await base.SendAsync(request, cancellationToken);
                    }
                }

                // Purge invalid credentials to cleanly force a fresh user session logon redirection
                await _tokenService.ClearTokens();
            }

            return response;
        }
    }
}