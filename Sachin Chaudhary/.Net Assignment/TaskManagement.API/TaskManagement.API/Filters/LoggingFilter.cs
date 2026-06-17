using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace TaskManagement.API.Filters
{
    public class LoggingFilter : IActionFilter
    {
        private Stopwatch _stopwatch;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch = Stopwatch.StartNew();

            Console.WriteLine($"URL: {context.HttpContext.Request.Path}");
            Console.WriteLine($"User: {context.HttpContext.User.Identity?.Name}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();

            Console.WriteLine($"StatusCode: {context.HttpContext.Response.StatusCode}");
            Console.WriteLine($"Execution Time: {_stopwatch.ElapsedMilliseconds} ms");
        }
    }
}