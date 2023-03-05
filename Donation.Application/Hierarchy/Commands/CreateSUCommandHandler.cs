using Donation.Application.Common.Persistence.Hierarchy;
using Donation.Domain.HierarchyAggregate;
using Donation.Domain.HierarchyAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Donation.Application.Hierarchy.Commands
{
  public class CreateSUCommandHandler : IRequestHandler<CreateSUCommand, ErrorOr<SU>>
  {
    private readonly ISURepo Repo;

    public CreateSUCommandHandler(ISURepo repo)
    {
      Repo = repo;
    }

    public async Task<ErrorOr<SU>> Handle(CreateSUCommand request, CancellationToken cancellationToken)
    {
      await Task.CompletedTask;
      var item = SU.Create(
          parentId: OUId.CreateUnique(),// OrgId.Create(request.ParentId),
          title: request.Title,
          description: request.Description);
      Repo.Add(item);
      return item;
    }
  }
}
