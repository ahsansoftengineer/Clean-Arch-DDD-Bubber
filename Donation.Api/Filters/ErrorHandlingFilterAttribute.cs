using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace Donation.Api.Filter
{
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var ex = context.Exception;
            // Why 1
            //context.Result = new ObjectResult(ex);

            // Way 2
            //context.Result =
            //  new ObjectResult(
            //    new
            //    {
            //      error = "Filters Processing Exception : " + ex.Message,
            //    })
            //  { StatusCode = 500 };

            // Way 3 Matches the Specification of content-type: application/problem+json; charset=utf-8 
            var problemDetails = new ProblemDetails()
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                Title = "Filters Processing Exception : " + ex.Message,
                Status = (int)HttpStatusCode.InternalServerError
            };

            context.Result = new ObjectResult(problemDetails);

            context.ExceptionHandled = true;
        }
    }
}
