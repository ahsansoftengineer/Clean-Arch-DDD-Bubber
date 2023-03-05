using Donation.Application.Common.Persistence.Hierarchy;
using Donation.Domain.HierarchyAggregate;
using Donation.Domain.HierarchyAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Donation.Application.Hierarchy.Commands
{
  public class CreateLECommandHandler : IRequestHandler<CreateLECommand, ErrorOr<LE>>
  {
    private readonly ILERepo Repo;

    public CreateLECommandHandler(ILERepo repo)
    {
      Repo = repo;
    }

    public async Task<ErrorOr<LE>> Handle(CreateLECommand request, CancellationToken cancellationToken)
    {
      await Task.CompletedTask;
      var item = LE.Create(
          parentId: BGId.CreateUnique(),// OrgId.Create(request.ParentId),
          title: request.Title,
          description: request.Description);
      Repo.Add(item);
      return item;
    }
  }
}
