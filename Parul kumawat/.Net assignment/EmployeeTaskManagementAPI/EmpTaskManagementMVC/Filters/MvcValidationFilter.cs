using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace EmpTaskManagementMVC.Filters
{
    public class MvcValidationFilter : ActionFilterAttribute
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
