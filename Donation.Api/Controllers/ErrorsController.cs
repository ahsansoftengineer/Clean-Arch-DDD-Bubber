using Donation.Application.Common.DuplicateEmailException;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Donation.Api.Controllers
{
    public class ErrorsController : ControllerBase
    {
        [HttpGet("/error")]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>().Error;

            var (statusCode, message) = exception switch
            {
                DuplicateEmailException => (StatusCodes.Status409Conflict, "ErrorController Message | Inner Message : " + exception.Message),
                _ => (StatusCodes.Status500InternalServerError, "No expected error occurred.")
            };
            return Problem(title: message, statusCode: statusCode);
        }
    }
}
