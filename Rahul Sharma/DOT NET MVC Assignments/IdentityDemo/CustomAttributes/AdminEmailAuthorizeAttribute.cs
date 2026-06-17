using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IdentityDemo.CustomAttributes
{
    public class AdminEmailAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new RedirectToActionResult("Login", "Login", null);
                return;
            }

            var email = user.Identity.Name;

            if (email != "admin@admin.com")
            {
                context.Result = new RedirectToActionResult("AccessDenied", "Login", null);
            }
        }
    }
}