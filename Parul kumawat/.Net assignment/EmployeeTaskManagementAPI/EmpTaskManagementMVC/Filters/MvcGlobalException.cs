using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace EmpTaskManagementMVC.Filters
{
    public class MvcGlobalException : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult(new
            {
                Message = context.Exception.Message,
            })
            {
                StatusCode = 500,
            };
            context.ExceptionHandled = true;
            
        }
    }
}
