using Donation.Application.Common.Persistence;
using Donation.Domain.Hierarchy;

namespace Donation.Application.Hierarchy.Commands
{
  public class CreateSUCommandHandler : CreateSimpleChildCommandHandler<ISURepo, SU>
  {
    public CreateSUCommandHandler(ISURepo repo): base (repo)
    {
    }
  }
}