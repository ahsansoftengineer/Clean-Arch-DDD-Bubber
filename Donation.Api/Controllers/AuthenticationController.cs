using Donation.Application.Authentication.Commands.Register;
using Donation.Application.Authentication.Common;
using Donation.Application.Authentication.Query.Login;
using Donation.Contracts.Authentication;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Donation.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
  private readonly IMediator mediator;

  public AuthenticationController(IMediator mediator)
  {
   this.mediator = mediator;
  }


  [HttpGet("check")]
  public IActionResult Check()
  {
    return Ok("Working Fine");
  }

  [HttpPost("register")]
  public async Task<IActionResult> Register(RegisterRequest request)
  {
    var command = new RegisterCommand(
    request.FirstName,
      request.LastName,
      request.Email,
      request.Password
      );
    ErrorOr<AuthenticationResult> authResult = await mediator.Send(command);
    return authResult.Match(
      authResult => Ok(MapAuthResult(authResult)),
      errors => Problem(errors));
  }


  [HttpPost("login")]
  public async Task<IActionResult> Login(LoginRequest request)
  {
    var query =  new LoginQuery(request.Email, request.Password);

    var authResult = await mediator.Send(query);

    return authResult.Match(
      authResult => Ok(MapAuthResult(authResult)),
      errors => Problem(errors));
  }

  private static AuthenticationResponse MapAuthResult(AuthenticationResult result)
  {
    return new AuthenticationResponse(
          result.user.Id,
             result.user.FirstName,
             result.user.LastName,
             result.user.Email,
             result.token
           );
  }

}


