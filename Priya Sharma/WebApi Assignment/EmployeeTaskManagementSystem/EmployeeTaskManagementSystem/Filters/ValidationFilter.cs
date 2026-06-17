using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TaskManagementSystemApi.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(new
                {
                    message = "Invalid input data",
                    errors = context.ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .Select(x => new
                        {
                            field = x.Key,
                            error = x.Value.Errors.First().ErrorMessage
                        })
                });
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
