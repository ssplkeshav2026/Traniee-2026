using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeTaskManagementSystemMVC.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(new
                {
                    Message = "Validation failed",
                    Errors = context.ModelState
                });
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
            
        
