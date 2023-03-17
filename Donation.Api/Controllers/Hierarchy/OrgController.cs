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
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
      var query = mapper.Map<SimpleQueryGetById<Org>>(id);

      var result = await mediator.Send(query);
      return result.Match(
        entity => Ok(mapper.Map<ResponseSimpleCreate>(entity)),
        errors => Problem(errors)
      );
    }

    [HttpGet()]
    public async Task<IActionResult> GetAll()
    {
      var query = mapper.Map<SimpleQueryGetAll<Org>>(new SimpleQueryGetAll<Org>());

      var createResult = await mediator.Send(query);
      return createResult.Match(
        entity => Ok(mapper.Map<List<ResponseSimpleCreate>>(entity)),
        errors => Problem(errors)
      );
    }

    [HttpGet("with-childs")]
    public async Task<IActionResult> GetAllWithChilds()
    {
      var query = mapper.Map<SimpleQueryGetAllwithChild<Org>>(new SimpleQueryGetAllwithChild<Org>());

      var createResult = await mediator.Send(query);
      return createResult.Match(
        entity => Ok(mapper.Map<List<SimpleResponseParentWithChild>>(entity)),
        errors => Problem(errors)
      );
    }
    [HttpPost]
    public async Task<IActionResult> Create(CommandRequestCreateSimple request)
    {
      var command = mapper.Map<SimpleCommandCreate<Org>>(request);
      var createResult = await mediator.Send(command);
      return createResult.Match(
        entity => Ok(mapper.Map<ResponseSimpleCreate>(entity)),
        errors => Problem(errors)
      );
    }

  }
}
