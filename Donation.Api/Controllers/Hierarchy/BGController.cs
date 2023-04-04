using Donation.Application.Simple;
using Donation.Contracts.Simple;
using Donation.Domain.HierarchyAggregate;
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
    public async Task<IActionResult> Create(CommandRequestCreateSimple request)
    {
      var command = mapper.Map<SimpleCommandCreate<BG>>(request);
      var createResult = await mediator.Send(command);
      return createResult.Match(
        entity => Ok(mapper.Map<ResponseSimpleCreate>(entity)),
        errors => Problem(errors)
      );
    }
  }
}
