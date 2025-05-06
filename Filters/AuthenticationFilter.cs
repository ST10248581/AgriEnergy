using AgriEnergyConnect.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AgriEnergyConnect.Filters
{
    public class AuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Check if the user is logged in by reading the environment variable
            if (!EnvironmentVariables._isLoggedIn ||
                EnvironmentVariables._userId == 0 ||
                EnvironmentVariables._userRoleId == 0 ||
                EnvironmentVariables._userRole == null)
            {
                // If the user is not logged in, redirect to the login page
                filterContext.Result = new RedirectResult("~/Account/Login");
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
