using Donation.Application.Hierarchy.Commands;
using Donation.Contracts.Simple;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Donation.Api.Controllers
{
  [Route("hierarchy/[controller]")]
  public class LEController : ApiController
  {
    private readonly IMapper mapper;
    private readonly ISender mediator;
    public LEController(IMapper mapper, ISender mediator)
    {
      this.mapper = mapper;
      this.mediator = mediator;
    }
    [HttpPost("{ParentId}")]
    public async Task<IActionResult> Create(SimpleChildCreateRequest request, Guid ParentId)
    {
      var command = mapper.Map<CreateLECommand>((request, ParentId));
      var createResult = await mediator.Send(command);
      return createResult.Match(
        entity => Ok(mapper.Map<SimpleChildCreateResponse>(entity)),
        errors => Problem(errors)
      );
    }

    //[HttpGet]
    //public async Task<IActionResult> Get(SimpleCreateRequest request)
    //{
    //  var command = mapper.Map<CreateSystemzCommand>(request);
    //  var createResult = await mediator.Send(command);
    //  return createResult.Match(
    //    entity => Ok(mapper.Map<SimpleChildCreateResponse>(entity)),
    //    errors => Problem(errors)
    //  );
    //}
  }
}
