using Donation.Application.Common.Persistence.Hierarchy;
using Donation.Domain.HierarchyAggregate;
using ErrorOr;
using MediatR;

namespace Donation.Application.Hierarchy.Commands
{
  public class CreateOrgCommandHandler : IRequestHandler<CreateOrgCommand, ErrorOr<Org>>
  {
    private readonly IOrgRepo Repo;

    public CreateOrgCommandHandler(IOrgRepo repo)
    {
      Repo = repo;
    }

    public async Task<ErrorOr<Org>> Handle(CreateOrgCommand request, CancellationToken cancellationToken)
    {
      await Task.CompletedTask;
      var item = Org.Create(
          title: request.Title,
          description: request.Description);
      Repo.Add(item);
      return item;
    }
  }
}
