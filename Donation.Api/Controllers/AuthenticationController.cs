using Donation.Application.Servicies.Authentication;
using Donation.Contracts.Authentication;
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
    var result = authenticationSvc.Register(
      request.FirstName,
      request.LastName,
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


