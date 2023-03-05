using Donation.Application.Common.Persistence.Hierarchy;
using Donation.Domain.HierarchyAggregate;
using Donation.Domain.HierarchyAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Donation.Application.Hierarchy.Commands
{
  public class CreateSystemzCommandHandler : IRequestHandler<CreateSystemzCommand, ErrorOr<Systemz>>
  {
    private readonly ISystemzRepo Repo;

    public CreateSystemzCommandHandler(ISystemzRepo repo)
    {
      Repo = repo;
    }

    public async Task<ErrorOr<Systemz>> Handle(CreateSystemzCommand request, CancellationToken cancellationToken)
    {
      await Task.CompletedTask;
      var item = Systemz.Create(
          parentId: OrgId.CreateUnique(),// OrgId.Create(request.ParentId),
          title: request.Title,
          description: request.Description);
      Repo.Add(item);
      return item;
    }
  }
}
