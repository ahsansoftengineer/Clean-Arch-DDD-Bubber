using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Donation.Api.Filter
{
  public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
  {
    public override void OnException(ExceptionContext context)
    {
      var exception = context.Exception;

      context.Result =
        new ObjectResult(
          new
          {
            error = "Filters Processing Exception : " + exception.Message,
          })
        { StatusCode = 500 };

      context.ExceptionHandled = true;
    }
  }
}
