using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeTaskManagementAPI.Filters
{
    public class LogsFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"Request Started: {context.HttpContext.Request.Path}");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"Request Ended: {context.HttpContext.Request.Path}");
        }

       
    }
}
