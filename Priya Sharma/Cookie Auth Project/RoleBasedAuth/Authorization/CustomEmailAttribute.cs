using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace RoleBasedAuth.Authorization
{
    public class CustomEmailAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            var email = user.FindFirstValue(ClaimTypes.Email);

            if (email != "admin@gmail.com")
            {
                context.Result =
                    new RedirectToActionResult(
                        "AccessDenied",
                        "User",
                        null);
            }
        }
    }
}






