using Donation.Application.Common.Errors;
using Donation.Application.Servicies.Authentication;
using Donation.Contracts.Authentication;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Donation.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
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
    Result<AuthenticationResult> registerResult = authenticationSvc.Register(
      request.FirstName,
      request.LastName,
      request.Email,
      request.Password
    );

    if(registerResult.IsSuccess)
    {
      return Ok(MapAuthResult(registerResult.Value));
    }
    var firstError = registerResult.Errors[0];

    if(firstError is DuplicationEmailError) 
    {
      return Problem(
        statusCode: StatusCodes.Status409Conflict,
        detail: "Fluent : AuthController : Email already exists"

        );
    }
    return Problem();

    // Old Way 2
    // Here we are returning Exception / Data based on Status of Result
    //return registerResult.Match(
    //  authResult => Ok(MapAuthResult(authResult)),
    //  _ => Problem(
    //      statusCode: StatusCodes.Status409Conflict, 
    //      title: "Authentication Controller : OneOf Library : Email Already Exists"
    //  )
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

  [HttpPost("login")]
  public IActionResult Login(LoginRequest request)
  {
    var result = authenticationSvc.Login(
      request.Email,
      request.Password
    );

    var response = new AuthenticationResponse(
      result.User.Id,
      result.User.FirstName,
      result.User.LastName,
      result.User.Email,
      result.Token
    );
    return Ok(response);
  }
}


