using Donation.Api.Common.Http;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Donation.Api.Controllers
{
  [ApiController]
  //[Authorize] // Uncomment for JWT
  [AllowAnonymous] // No Authorization for Every Child Controller
  public class ApiController : ControllerBase
  {
    protected IActionResult Problem(List<Error> errors)
    {
      if (errors.Count is 0)
      {
        return Problem();
      }

      if (errors.All(error => error.Type == ErrorType.Validation))
      {
        return ValidationProblemz(errors);
      }
      // If you Customize your Validation Code
      if (errors.All(error => error.NumericType == 23))
      {
        return ValidationProblemz(errors);
      }

      // HttpContext is accessible inside Controller
      HttpContext.Items[HttpContextItemKeys.Errors] = errors;

      var firstError = errors[0];

      return Problemz(firstError);
    }

    private IActionResult Problemz(Error error)
    {
      var statusCode = error.Type switch
      {
        ErrorType.Conflict => StatusCodes.Status409Conflict,
        ErrorType.Validation => StatusCodes.Status400BadRequest,
        ErrorType.NotFound => StatusCodes.Status404NotFound,
        _ => StatusCodes.Status500InternalServerError,
      };

      // Coming From ControllerBase
      return Problem(statusCode: statusCode, title: error.Description);
    }

    private IActionResult ValidationProblemz(List<Error> errors)
    {
      var modelStateDic = new ModelStateDictionary();

      foreach (var error in errors)
      {
        modelStateDic.AddModelError(
          error.Code,
          error.Description
       );
      }

      // Coming From ControllerBase
      return ValidationProblem(modelStateDic);
    }
  }
}
