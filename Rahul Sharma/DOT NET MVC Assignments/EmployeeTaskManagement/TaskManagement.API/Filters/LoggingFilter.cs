using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TaskManagement.API.Filters
{
    public class LoggingFilter : IActionFilter
    {
        private readonly ILogger<LoggingFilter> _logger;
        private readonly Stopwatch _stopwatch;

        public LoggingFilter(ILogger<LoggingFilter> logger)
        {
            _logger = logger;
            _stopwatch = new Stopwatch();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch.Start();

            var url = context.HttpContext.Request.Path;
            var user = context.HttpContext.User.Identity?.Name ?? "Anonymous";

            _logger.LogInformation("Request started. URL: {Url}, User: {User}", url, user);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();

            var url = context.HttpContext.Request.Path;
            var user = context.HttpContext.User.Identity?.Name ?? "Anonymous";
            var statusCode = context.HttpContext.Response.StatusCode;
            var executionTime = _stopwatch.ElapsedMilliseconds;

            _logger.LogInformation(
                "Request completed. URL: {Url}, User: {User}, StatusCode: {StatusCode}, ExecutionTime: {ExecutionTime}ms",
                url,
                user,
                statusCode,
                executionTime);
        }
    }
}