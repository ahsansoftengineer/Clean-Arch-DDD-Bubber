using Donation.Application.Common.Persistence.Hierarchy;
using Donation.Application.Simple;
using Donation.Domain.HierarchyAggregate;
using Donation.Domain.SimpleAggregates;
using ErrorOr;
using MediatR;

namespace Donation.Application.Hierarchy.Commands
{
  public class CommandHandlerCreateLE : IRequestHandler<SimpleCommandChildCreate<LE>, ErrorOr<LE>>
  {
    private readonly ILERepo Repo;

    public CommandHandlerCreateLE(ILERepo repo)
    {
      Repo = repo;
    }

    public async Task<ErrorOr<LE>> Handle(SimpleCommandChildCreate<LE> request, CancellationToken cancellationToken)
    {
      await Task.CompletedTask;
      var item = LE.Create(
          parentId: SimpleValueObject.Create(request.ParentId),
          title: request.Title,
          description: request.Description);
      Repo.Add(item);
      return item;
    }
  }
}
