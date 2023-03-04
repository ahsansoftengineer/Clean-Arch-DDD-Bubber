using Donation.Application.Common.Persistence;
using Donation.Domain.Hierarchy;

namespace Donation.Application.Hierarchy.Commands
{
  public class CreateLECommandHandler : CreateSimpleChildCommandHandler<ILERepo, LE>
  {
    public CreateLECommandHandler(ILERepo repo): base (repo)
    {
    }
  }
}
