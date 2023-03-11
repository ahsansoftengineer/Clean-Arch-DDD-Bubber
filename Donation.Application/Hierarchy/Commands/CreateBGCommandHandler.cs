using Donation.Application.Common.Persistence;
using Donation.Application.Common.Persistence.Hierarchy;
using Donation.Application.Simple;
using Donation.Domain.HierarchyAggregate;
using Donation.Domain.SimpleAggregates;
using ErrorOr;
using MediatR;

namespace Donation.Application.Hierarchy.Commands
{
  public class CreateBGCommandHandler : IRequestHandler<SimpleCommandCreate<BG>, ErrorOr<BG>>
  {
    private readonly IBGRepo Repo;

    public CreateBGCommandHandler(IBGRepo repo)
    {
      Repo = repo;
    }

    public async Task<ErrorOr<BG>> Handle(SimpleCommandCreate<BG> request, CancellationToken cancellationToken)
    {
      await Task.CompletedTask;
      var item = BG.Create(
          title: request.Title,
          description: request.Description);
      Repo.Add(item);
      return item;
    }
  }
}
