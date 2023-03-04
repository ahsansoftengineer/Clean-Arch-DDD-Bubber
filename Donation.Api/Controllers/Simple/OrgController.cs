using Donation.Application.Common.Commands;
using Donation.Application.Menus.Commands.CreateMenu;
using Donation.Contracts.Common;
using Donation.Contracts.Menus;
using Donation.Domain.Hierarchy;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Donation.Api.Controllers.Simple
{
  [Route("org")]
  public class OrgController : ApiController
  {
    private readonly IMapper mapper;
    private readonly ISender mediator;
    public OrgController(IMapper mapper, ISender mediator)
    {
      this.mapper = mapper;
      this.mediator = mediator;
    }
    //[HttpPost]
    //public async Task<IActionResult> Create(CreateSimpleRequest request)
    //{
    //  var command = mapper.Map<CreateSimpleCommand<Org>>((request));
    //  var createMenuResult = await mediator.Send(command);
    //  return createMenuResult.Match(
    //    menu => Ok(mapper.Map<SimpleResponse>(menu)),
    //    errors => Problem(errors)
    //  );

    //  //CreatedAtAction(nameof(GetMenu), new {hostId, menu}) ,
    //}

  }
}
