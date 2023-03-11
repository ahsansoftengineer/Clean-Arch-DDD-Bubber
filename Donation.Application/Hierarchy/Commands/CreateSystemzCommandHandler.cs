using Donation.Application.Common.Persistence.Hierarchy;
using Donation.Application.Simple;
using Donation.Domain.HierarchyAggregate;
using Donation.Domain.SimpleAggregates;
using ErrorOr;
using MediatR;

namespace Donation.Application.Hierarchy.Commands
{
  public class CreateSystemzCommandHandler : IRequestHandler<SimpleCommandChildCreate<Systemz>, ErrorOr<Systemz>>
  {
    private readonly ISystemzRepo Repo;

    public CreateSystemzCommandHandler(ISystemzRepo repo)
    {
      Repo = repo;
    }

    public async Task<ErrorOr<Systemz>> Handle(SimpleCommandChildCreate<Systemz> request, CancellationToken cancellationToken)
    {
      await Task.CompletedTask;
      var item = Systemz.Create(
          parentId: SimpleValueObject.Create(request.ParentId),// OrgId.Create(request.ParentId),
          title: request.Title,
          description: request.Description);
      Repo.Add(item);
      return item;
    }
  }
}
