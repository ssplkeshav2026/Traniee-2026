using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TaskManagement.API.Helpers.Exceptions;

namespace TaskManagement.API.Filters
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
            _logger.LogError(context.Exception, "Exception occurred.");

            var exception = context.Exception;

            context.Result = exception switch
            {
                BadRequestException => new BadRequestObjectResult(new
                {
                    StatusCode = 400,
                    Message = exception.Message
                }),

                UnauthorizedException => new ObjectResult(new
                {
                    StatusCode = 401,
                    Message = exception.Message
                })
                {
                    StatusCode = 401
                },

                ForbiddenException => new ObjectResult(new
                {
                    StatusCode = 403,
                    Message = exception.Message
                })
                {
                    StatusCode = 403
                },

                NotFoundException => new NotFoundObjectResult(new
                {
                    StatusCode = 404,
                    Message = exception.Message
                }),

                _ => new ObjectResult(new
                {
                    StatusCode = 500,
                    Message = "Something went wrong. Please try again later."
                })
                {
                    StatusCode = 500
                }
            };

            context.ExceptionHandled = true;
        }
    }
}