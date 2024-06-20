using Microsoft.AspNetCore.Mvc.Filters;

namespace TerceiroSetor.Api.Middlewares
{
    public class RequiredHeaderAttribute : Attribute, IActionFilter
    {
        private readonly string _requiredHeader;

        public RequiredHeaderAttribute(string requiredHeader)
        {
            _requiredHeader = requiredHeader;
        }

        public void OnActionExecuted(ActionExecutedContext context) {}

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Headers.
                TryGetValue(_requiredHeader, out _))
            {
                throw new Exception($"Missing Header Exception: {_requiredHeader}");
            }
        }
    }
}
