using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TaskManagement.MVC.Helpers
{
    public class AuthenticatingHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticatingHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Retrieve token from session or cookie container storage
            var token = _httpContextAccessor.HttpContext?.Session?.GetString("JWToken");

            if (!string.IsNullOrEmpty(token))
            {
                // ✅ ATTACH JWT AUTHENTICATION HEADER
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}