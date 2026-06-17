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

         
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var refreshToken = await _tokenService.GetRefreshToken();

                if (string.IsNullOrEmpty(refreshToken))
                {
                    return response;
                }

                using var client = new HttpClient();

        
                var baseUrl = (_configuration["ApiSettings:BaseUrl"] ?? "http://localhost:5072").Trim();

                if (baseUrl.EndsWith("/"))
                {
                    baseUrl = baseUrl.TrimEnd('/');
                }

                var refreshUrl = $"{baseUrl}/api/auth/refresh-token";

                var refreshRequest = new { RefreshToken = refreshToken };
                var json = JsonConvert.SerializeObject(refreshRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");


                var refreshResponse = await client.PostAsync(refreshUrl, content, cancellationToken);

                if (refreshResponse.IsSuccessStatusCode)
                {
                    var data = await refreshResponse.Content.ReadAsStringAsync();
                    var tokens = JsonConvert.DeserializeObject<AuthResponseViewModel>(data);

                    if (tokens != null)
                    {
                        await _tokenService.SetTokens(tokens.AccessToken, tokens.RefreshToken);

              
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokens.AccessToken);
                        return await base.SendAsync(request, cancellationToken);
                    }
                }


                await _tokenService.ClearTokens();
            }

            return response;
        }
    }
}