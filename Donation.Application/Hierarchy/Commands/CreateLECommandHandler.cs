using Donation.Application.Common.Persistence.Hierarchy;
using Donation.Application.Simple;
using Donation.Domain.HierarchyAggregate;
using Donation.Domain.HierarchyAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Donation.Application.Hierarchy.Commands
{
  public class CreateLECommandHandler : IRequestHandler<SimpleCommandChildCreate<LE>, ErrorOr<LE>>
  {
    private readonly ILERepo Repo;

    public CreateLECommandHandler(ILERepo repo)
    {
      Repo = repo;
    }

    public async Task<ErrorOr<LE>> Handle(SimpleCommandChildCreate<LE> request, CancellationToken cancellationToken)
    {
      await Task.CompletedTask;
      var item = LE.Create(
          parentId: BGId.Create(request.ParentId),// OrgId.Create(request.ParentId),
          title: request.Title,
          description: request.Description);
      Repo.Add(item);
      return item;
    }
  }
}
