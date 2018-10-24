using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace SimpleRestApiUtility
{
    public class HandleExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnException(actionExecutedContext);
            actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Something went wrong. Please try again later!", actionExecutedContext.Exception);
        }
    }
}
