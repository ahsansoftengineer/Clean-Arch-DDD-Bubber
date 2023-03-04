using Donation.Application.Common.Commands;
using Donation.Application.Common.Persistence;
using Donation.Domain.Hierarchy;
using ErrorOr;
using MediatR;

namespace Donation.Application.Hierarchy.Commands
{
  public class CreateOrgCommandHandler : CreateSimpleCommandHandler<IOrgRepo, Org>
  {
    public CreateOrgCommandHandler(IOrgRepo repo) : base (repo)
    {
    }
  }
}
