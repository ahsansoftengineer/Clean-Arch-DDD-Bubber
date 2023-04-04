using Donation.Application.Common.Persistence.Hierarchy;
using Donation.Application.Simple;
using Donation.Domain.HierarchyAggregate;
using Donation.Domain.SimpleAggregates;
using ErrorOr;
using MediatR;

namespace Donation.Application.Hierarchy.Commands
{
  public class CommandHandlerCreateSU : IRequestHandler<SimpleCommandChildCreate<SU>, ErrorOr<SU>>
  {
    private readonly ISURepo Repo;

    public CommandHandlerCreateSU(ISURepo repo)
    {
      Repo = repo;
    }

    public async Task<ErrorOr<SU>> Handle(SimpleCommandChildCreate<SU> request, CancellationToken cancellationToken)
    {
      await Task.CompletedTask;
      var item = SU.Create(
          parentId: SimpleValueObject.Create(request.ParentId),
          title: request.Title,
          description: request.Description);
      Repo.Add(item);
      return item;
    }
  }
}
