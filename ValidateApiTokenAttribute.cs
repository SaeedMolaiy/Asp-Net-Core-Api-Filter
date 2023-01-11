using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiFilterAttribute.Filter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ValidateApiTokenAttribute : Attribute, IAsyncActionFilter
    {
        private const string ApiTokenHeaderName = "ApiToken";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            if (!context.HttpContext.Request.Headers.TryGetValue(ApiTokenHeaderName, out var ApiToken))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var apiToken = context.HttpContext.Request.Headers[ApiTokenHeaderName];

            //Check Api Token Sent by Client is Valid or not

            if (false)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }
}
