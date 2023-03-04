using Donation.Application.Common.Commands;
using Donation.Application.Common.Persistence;
using Donation.Domain.Common.Models;
using Donation.Domain.Hierarchy;
using ErrorOr;
using MediatR;

namespace Donation.Application.Hierarchy.Commands
{
  public class CreateSimpleChildCommandHandler : CreateSimpleChildCommandHandler<ISystemzRepo, Systemz>
  {
    public CreateSimpleChildCommandHandler(ISystemzRepo repo): base (repo)
    {
    }
  }
}
