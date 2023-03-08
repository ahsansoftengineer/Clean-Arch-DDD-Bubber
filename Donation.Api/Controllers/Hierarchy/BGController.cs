using Donation.Application.Hierarchy.Commands;
using Donation.Contracts.Simple;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Donation.Api.Controllers
{
  [Route("hierarchy/[controller]")]
  public class BGController : ApiController
  {
    private readonly IMapper mapper;
    private readonly ISender mediator;
    public BGController(IMapper mapper, ISender mediator)
    {
      this.mapper = mapper;
      this.mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> Create(SimpleCreateRequest request)
    {
      var command = mapper.Map<CreateBGCommand>(request);
      var createResult = await mediator.Send(command);
      return createResult.Match(
        entity => Ok(mapper.Map<SimpleCreateResponse>(entity)),
        errors => Problem(errors)
      );
    }
  }
}
