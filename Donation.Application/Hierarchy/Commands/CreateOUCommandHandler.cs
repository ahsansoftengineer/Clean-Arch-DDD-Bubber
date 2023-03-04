using Donation.Application.Common.Persistence;
using Donation.Domain.Hierarchy;

namespace Donation.Application.Hierarchy.Commands
{
  public class CreateOUCommandHandler : CreateSimpleChildCommandHandler<IOURepo, OU>
  {
    public CreateOUCommandHandler(IOURepo repo): base (repo)
    {
    }
  }
}
