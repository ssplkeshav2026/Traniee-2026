using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TaskManagement.API.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult(new
            {
                Success = false,
                Message = "Internal Server Error",
                Error = context.Exception.Message
            })
            {
                StatusCode = 500
            };

            context.ExceptionHandled = true;
        }
    }
}