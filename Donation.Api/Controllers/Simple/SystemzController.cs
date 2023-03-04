using Donation.Application.Common.Commands;
using Donation.Contracts.Common;
using Donation.Domain.Hierarchy;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Donation.Api.Controllers.Simple
{
  [Route("systemz")]
  public class SystemzController : ApiController
  {
    private readonly IMapper mapper;
    private readonly ISender mediator;
    public SystemzController(IMapper mapper, ISender mediator)
    {
      this.mapper = mapper;
      this.mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateSimpleRequest request)
    {
      var command = mapper.Map<CreateSimpleCommand<Systemz>>((request));
      var createMenuResult = await mediator.Send(command);
      return createMenuResult.Match(
        menu => Ok(mapper.Map<SimpleChildResponse>(menu)),
        errors => Problem(errors)
      );
    }

  }
}
