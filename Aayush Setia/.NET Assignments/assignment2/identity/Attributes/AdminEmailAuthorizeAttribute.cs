using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace identity.Attributes
{
    public class AdminEmailAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new RedirectToActionResult(
                    "Login", "Account",null);
                return;
            }     
            
            string? email = user.Identity.Name;

            if (email != "admin@admin.com")
            {
                context.Result = new ContentResult
                {
                    Content = "Access Denied"
                };
            }
        }
    }
}