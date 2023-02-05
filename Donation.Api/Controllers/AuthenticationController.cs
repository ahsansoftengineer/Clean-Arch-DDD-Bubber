using Donation.Application.Services.Authentication.Command;
using Donation.Application.Services.Authentication.Common;
using Donation.Application.Services.Authentication.Query;
using Donation.Contracts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace Donation.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
  private readonly IAuthenticationCommandService authenticationCommandService;
  private readonly IAuthenticationQueryService authenticationQueryService;

  public AuthenticationController(
    IAuthenticationCommandService authenticationCommandService, 
    IAuthenticationQueryService authenticationQueryService)
  {
    this.authenticationCommandService = authenticationCommandService;
    this.authenticationQueryService = authenticationQueryService;
  }


  [HttpGet("check")]
  public IActionResult Check()
  {
    return Ok("Working Fine");
  }

  [HttpPost("register")]
  public IActionResult Register(RegisterRequest request)
  {
    ErrorOr<AuthenticationResult> authResult = authenticationCommandService.Register(
      request.FirstName,
      request.LastName,
      request.Email,
      request.Password
    );
    return authResult.Match(
      authResult => Ok(MapAuthResult(authResult)),
      errors => Problem(errors));
  }


  [HttpPost("login")]
  public IActionResult Login(LoginRequest request)
  {

    var authResult = authenticationQueryService.Login(
      request.Email,
      request.Password
    );
    return authResult.Match(
      authResult => Ok(MapAuthResult(authResult)),
      errors => Problem(errors));
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


