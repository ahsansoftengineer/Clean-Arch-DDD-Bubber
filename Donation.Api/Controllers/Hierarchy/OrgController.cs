using Donation.Application.Simple;
using Donation.Contracts.Simple;
using Donation.Domain.HierarchyAggregate;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Donation.Api.Controllers
{
  [Route("hierarchy/[controller]")]
  [AllowAnonymous]
  public class OrgController : ApiController
  {
    private readonly IMapper mapper;
    private readonly ISender mediator;
    public OrgController(IMapper mapper, ISender mediator)
    {
      this.mapper = mapper;
      this.mediator = mediator;
    }
    [HttpGet("{orgId}")]
    public async Task<IActionResult> GetById([FromRoute] Guid orgId)
    {
      var query = mapper.Map<SimpleQueryGetById<Org>>(orgId);

      var createResult = await mediator.Send(query);
      return createResult.Match(
        entity => Ok(mapper.Map<SimpleResponseCreate>(entity)),
        errors => Problem(errors)
      );
    }

    [HttpPost]
    public async Task<IActionResult> Create(SimpleRequestCreate request)
    {
      var command = mapper.Map<SimpleCommandCreate<Org>>(request);
      var createResult = await mediator.Send(command);
      return createResult.Match(
        entity => Ok(mapper.Map<SimpleResponseCreate>(entity)),
        errors => Problem(errors)
      );
    }

  }
}
