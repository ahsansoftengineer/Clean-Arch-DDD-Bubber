using Donation.Application.Hierarchy.Commands;
using Donation.Application.Simple;
using Donation.Contracts.Simple;
using Donation.Domain.HierarchyAggregate;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Donation.Api.Controllers
{
  [Route("hierarchy/[controller]")]
  public class SystemzController : ApiController
  {
    private readonly IMapper mapper;
    private readonly ISender mediator;
    public SystemzController(IMapper mapper, ISender mediator)
    {
      this.mapper = mapper;
      this.mediator = mediator;
    }
    [HttpGet()]
    public async Task<IActionResult> GetAll()
    {
      var query = mapper.Map<SimpleQueryGetAll<Systemz>>(
        new SimpleQueryGetAll<Systemz>()
      );

      var createResult = await mediator.Send(query);
      return createResult.Match(
        entity => Ok(mapper.Map<List<SimpleResponseChildCreate>>(entity)),
        errors => Problem(errors)
      );
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
      var query = mapper.Map<SimpleQueryGetById<Systemz>>(id);
      var result = await mediator.Send(query);
      return result.Match(
        entity => Ok(mapper.Map<SimpleResponseChildCreate>(entity)),
        errors => Problem(errors)
      );
    }
    [HttpGet("with-parent")]
    public async Task<IActionResult> GetAllWithParent()
    {
      var query = mapper.Map<SimpleQueryGetAllwithParent<Systemz>>(
        new SimpleQueryGetAllwithParent<Systemz>()
      );
      var createResult = await mediator.Send(query);
      return createResult.Match(
        entity => Ok(mapper.Map<List<SimpleResponseChildwithParent>>(entity)),
        errors => Problem(errors)
      );
    }
    [HttpGet("with-parent/{id}")]
    public async Task<IActionResult> GetByIdwithParent([FromRoute] Guid id)
    {
      var query = mapper.Map<SimpleQueryGetByIdwithParent<Systemz>>(id);

      var result = await mediator.Send(query);
      return result.Match(
        entity => Ok(mapper.Map<SimpleResponseChildwithParent>(entity)),
        errors => Problem(errors)
      );
    }

    [HttpPost()]
    public async Task<IActionResult> Create(CommandRequestCreateSimpleChild request)
    {
      var command = mapper.Map<SimpleCommandChildCreate<Systemz>>(request);
      var createResult = await mediator.Send(command);
      return createResult.Match(
        entity => Ok(mapper.Map<SimpleResponseChildCreate>(entity)),
        errors => Problem(errors)
      );
    }
    
  }
}
