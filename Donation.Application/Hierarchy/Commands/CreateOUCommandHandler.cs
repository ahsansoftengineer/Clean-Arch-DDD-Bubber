using Donation.Application.Common.Persistence.Hierarchy;
using Donation.Application.Simple;
using Donation.Domain.HierarchyAggregate;
using Donation.Domain.HierarchyAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Donation.Application.Hierarchy.Commands
{
  public class CreateOUCommandHandler : IRequestHandler<SimpleCommandChildCreate<OU>, ErrorOr<OU>>
  {
    private readonly IOURepo Repo;

    public CreateOUCommandHandler(IOURepo repo)
    {
      Repo = repo;
    }

    public async Task<ErrorOr<OU>> Handle(SimpleCommandChildCreate<OU> request, CancellationToken cancellationToken)
    {
      await Task.CompletedTask;
      var item = OU.Create(
          parentId: LEId.Create(request.ParentId),// OrgId.Create(request.ParentId),
          title: request.Title,
          description: request.Description);
      Repo.Add(item);
      return item;
    }
  }
}
