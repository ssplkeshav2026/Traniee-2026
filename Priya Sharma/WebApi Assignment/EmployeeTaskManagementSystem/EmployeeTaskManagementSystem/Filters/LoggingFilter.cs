using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace TaskManagementSystemApi.Filters
{
    public class LoggingFilter : IAsyncActionFilter
    {
        private readonly ILogger<LoggingFilter> _logger;

        public LoggingFilter(ILogger<LoggingFilter> logger)
        {
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            var startTime = Stopwatch.StartNew();

            var url = context.HttpContext.Request.Path;
            var user = context.HttpContext.User.Identity?.Name ?? "Anonymous";

            _logger.LogInformation($"START → URL: {url}, User: {user}");

            var result = await next(); 

            startTime.Stop();

            var statusCode = result.HttpContext.Response.StatusCode;

            _logger.LogInformation(
                $"END → URL: {url}, User: {user}, Status: {statusCode}, Time: {startTime.ElapsedMilliseconds}ms"
            );
        }
    }
}
