using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TaskManagement.MVC.Filters
{
    public class LoggingFilter : IAsyncActionFilter
    {
        private readonly ILogger<LoggingFilter> _logger;

        public LoggingFilter(ILogger<LoggingFilter> logger)
        {
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var stopwatch = Stopwatch.StartNew();

            // Request details capture karein before execution
            var requestUrl = context.HttpContext.Request.Path + context.HttpContext.Request.QueryString;
            var user = context.HttpContext.User?.Identity?.Name ?? "Anonymous/Unauthenticated User";

            // Next middleware/action execute hone dein
            var executedContext = await next();

            stopwatch.Stop();
            var executionTime = stopwatch.ElapsedMilliseconds;
            var statusCode = context.HttpContext.Response.StatusCode;

            // Clean, structural console and log outputs
            _logger.LogInformation(
                "--- [HTTP METRICS LOG] ---\n" +
                "Request URL: {Url}\n" +
                "Triggered By User: {User}\n" +
                "HTTP Status Code: {StatusCode}\n" +
                "Execution Performance: {ExecutionTime} ms\n" +
                "--------------------------",
                requestUrl, user, statusCode, executionTime
            );
        }
    }
}