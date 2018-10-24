using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SimpleRestApiUtility
{
    public class ValidateIdAttribute : ActionFilterAttribute
    {
        private readonly string[] _requiredParams;

        public ValidateIdAttribute(params string[] requiredParams)
        {
            _requiredParams = requiredParams;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var modelState = actionContext.ModelState;
            var arguments = actionContext.ActionArguments;
            foreach (var param in _requiredParams)
            {
                object value;
                if (!arguments.TryGetValue(param, out value) || (int)value > 0)
                {
                    modelState.AddModelError(param, $"'{param}' must be greater then 0.");
                }
            }

            if (!modelState.IsValid)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, modelState);
            }
        }
    }
}
