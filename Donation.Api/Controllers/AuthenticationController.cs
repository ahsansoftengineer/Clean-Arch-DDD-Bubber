using Donation.Application.Authentication.Commands.Register;
using Donation.Application.Authentication.Common;
using Donation.Application.Authentication.Query.Login;
using Donation.Contracts.Authentication;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Donation.Api.Controllers;

[Route("auth")]
[AllowAnonymous] // This will authorize this end point with authorization
public class AuthenticationController : ApiController
{
  private readonly IMediator mediator;
  private readonly IMapper mapper;

  public AuthenticationController(IMediator mediator, IMapper mapper)
  {
    this.mediator = mediator;
    this.mapper = mapper;
  }

  [NonAction]
  public string myLocalFuncation()
  {
    return "No Action Counted in Swagger";
  }

  [HttpGet("check")]
  public IActionResult Check()
  {
    return Ok("Working Fine");
  }

  [HttpPost("register")]
  public async Task<IActionResult> Register(RegisterRequest request)
  {
    var command = mapper.Map<RegisterCommand>(request);
    ErrorOr<AuthenticationResult> authResult = await mediator.Send(command);
    return authResult.Match(
      authResult => Ok(mapper.Map<AuthenticationResponse>(authResult)),
      errors => Problem(errors));
  }


  [HttpPost("login")]
  public async Task<IActionResult> Login(LoginRequest request)
  {
    var query = mapper.Map<LoginQuery>(request);

    var authResult = await mediator.Send(query);

    return authResult.Match(
      authResult => Ok(mapper.Map<AuthenticationResponse>(authResult)),
      errors => Problem(errors));
  }
}


