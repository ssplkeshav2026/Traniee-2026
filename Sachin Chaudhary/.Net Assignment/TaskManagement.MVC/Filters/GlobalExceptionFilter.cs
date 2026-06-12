using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Net;

namespace TaskManagement.MVC.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            // Exception message trace log karein
            _logger.LogError(context.Exception, "An unhandled runtime error bypass occurred inside the pipeline framework.");

            // Check kijiye request AJAX hai ya normal HTML view navigation
            bool isAjaxRequest = context.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest" ||
                                 context.HttpContext.Request.ContentType?.Contains("application/json") == true;

            if (isAjaxRequest)
            {
                // AJAX requests ke liye proper JSON standard package return karein
                var jsonResponse = new
                {
                    Success = false,
                    Message = "An unexpected server error occurred.",
                    Detail = context.Exception.Message
                };

                context.Result = new ObjectResult(jsonResponse)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
            else
            {
                // Normal standard route requests ke liye general Error View template par redirect karein
                context.Result = new RedirectToActionResult("Error", "Home", null);
            }

            // Exception ko fully handled mark karein taaki loop ya runtime breaks na ho skyen
            context.ExceptionHandled = true;
        }
    }
}