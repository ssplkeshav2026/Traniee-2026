using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RoleBasedAuth.CustomAttributes
{
    public class AuthAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            var email = context.HttpContext.User.Identity.Name;
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new RedirectToActionResult("Login", "Home", null);
                return;
            }
            var controller = context.RouteData.Values["controller"]?.ToString();
            var action = context.RouteData.Values["action"]?.ToString();

            if (controller == "Admin" && action == "Dashboard")
            {
                return;
            }

            if (controller == "Home" && action == "Index")
            {
                return;
            }
            if (controller == "Home" && action == "Privacy" && email == "admin@admin.com")
            {
                return;
            }
            if (email == "admin@admin.com")
            {
                context.Result = new RedirectToActionResult("Dashboard", "Admin", null);
                return;
            }if(email != "admin@admin.com")
            {
                context.Result = new RedirectToActionResult("AccessDenied", "Home", null);

            }



        }
    }
}
