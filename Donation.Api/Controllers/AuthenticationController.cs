using Donation.Application.Servicies.Authentication;
using Donation.Contracts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace Donation.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
  private readonly IAuthenticationService authenticationSvc;

  public AuthenticationController(IAuthenticationService authenticationSvc)
  {
    this.authenticationSvc = authenticationSvc;
  }


  [HttpGet("check")]
  public IActionResult Check()
  {
    return Ok("Working Fine");
  }

  [HttpPost("register")]
  public IActionResult Register(RegisterRequest request)
  {
    ErrorOr<AuthenticationResult> authResult = authenticationSvc.Register(
      request.FirstName,
      request.LastName,
      request.Email,
      request.Password
    );
    // Way 1 : ErrorOr Match
    return authResult.Match(
      authResult => Ok(MapAuthResult(authResult)),
      errors => Problem(errors));

    // Way 2 : ErrorOr MatchFirst
    //return authResult.MatchFirst(
    //  authResult => Ok(MapAuthResult(authResult)),
    //  firstResult => Problem(
    //    statusCode: StatusCodes.Status409Conflict,
    //    title: firstResult.Description
    //  )
    //);
  }


  [HttpPost("login")]
  public IActionResult Login(LoginRequest request)
  {

    var authResult = authenticationSvc.Login(
      request.Email,
      request.Password
    );
    // This Approach has the ability we still add more exception handling here

    if(authResult.IsError && authResult.FirstError == Donation.Domain.Common.Errors.Authentication.InvalidEmail)
    {
      return Problem(
        statusCode: StatusCodes.Status203NonAuthoritative,
        title: "ErrorOr : AuthController : Invalid Email from Controller"
        );
    }

    // This is for Handling List<Errors>
    return authResult.Match(
      authResult => Ok(MapAuthResult(authResult)),
      errors => Problem(errors));

    // When Single Error
    //return result.MatchFirst(
    //  authResult => Ok(MapAuthResult(authResult)),
    //  firstResult => Problem(
    //    statusCode: StatusCodes.Status409Conflict,
    //    title: firstResult.Description
    // )
    //);
  }

  private static AuthenticationResponse MapAuthResult(AuthenticationResult result)
  {
    return new AuthenticationResponse(
          result.User.Id,
             result.User.FirstName,
             result.User.LastName,
             result.User.Email,
             result.Token
           );
  }

}


