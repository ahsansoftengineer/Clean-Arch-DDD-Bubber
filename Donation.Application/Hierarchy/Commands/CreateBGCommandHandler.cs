using Donation.Application.Common.Commands;
using Donation.Application.Common.Persistence;
using Donation.Domain.Hierarchy;
using ErrorOr;
using MediatR;

namespace Donation.Application.Hierarchy.Commands
{
  public class CreateBGCommandHandler : CreateSimpleCommandHandler<IBGRepo, BG>
  {
    public CreateBGCommandHandler(IBGRepo repo): base (repo)
    {
    }
  }
}
