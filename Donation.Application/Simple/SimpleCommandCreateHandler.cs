using Donation.Application.Common.Persistence;
using Donation.Domain.SimpleAggregates;
using ErrorOr;
using MediatR;

namespace Donation.Application.Simple
{
  public class SimpleCommandCreateHandler<TCommand, TRepo> : IRequestHandler<TCommand, ErrorOr<SimpleAggregate>>
  where TCommand : SimpleCommandCreate<SimpleAggregate>
  where TRepo : ISimpleRepo<SimpleAggregate>
  {
    private readonly TRepo Repo;

    public SimpleCommandCreateHandler(TRepo repo)
    {
      Repo = repo;
    }

    public async Task<ErrorOr<SimpleAggregate>> Handle(TCommand request, CancellationToken cancellationToken)
    {
      await Task.CompletedTask;
      var item = SimpleAggregate.Create(
          title: request.Title,
          description: request.Description);

      //var result = TCommand.MakeGenericType(typeof(SimpleAggregate));
      //dynamic configurationInstance = Activator.CreateInstance(result);
      Repo.Add(item);
      return item;
    }
  }
}
