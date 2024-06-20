using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TerceiroSetor.Api.Middlewares
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
                if (context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "X-Tenant").Value !=
                    context.HttpContext.Request.Headers["X-Tenant"])
                {
                    context.Result = new UnauthorizedResult();
                }
        }
    }
}
