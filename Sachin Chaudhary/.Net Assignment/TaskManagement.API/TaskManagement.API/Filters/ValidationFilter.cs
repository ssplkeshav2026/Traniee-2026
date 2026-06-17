using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TaskManagement.API.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(new
                {
                    Success = false,
                    Message = "Validation Failed",
                    Errors = context.ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .Select(x => new
                        {
                            Field = x.Key,
                            Errors = x.Value.Errors
                                .Select(e => e.ErrorMessage)
                        })
                });
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}