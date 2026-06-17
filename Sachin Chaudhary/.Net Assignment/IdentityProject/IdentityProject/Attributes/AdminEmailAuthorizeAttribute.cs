using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;


namespace IdentityProject.CustomAttributes
{
    public class AdminEmailAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
           
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new RedirectToActionResult(
                    "Login",
                    "Account",
                    null);

                return;
            }

         
            var email = context.HttpContext.User.FindFirstValue(ClaimTypes.Email);

          
            if (email != "admin@admin.com")
            {
                context.Result = new ContentResult
                {
                    Content = "Access Denied. This area is only for Admin."
                };
            }
        }
    }
}