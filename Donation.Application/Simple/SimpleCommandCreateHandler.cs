using Donation.Domain.SimpleAggregates;
using ErrorOr;
using MediatR;

// It cannot be Generic we are so behind
namespace Donation.Application.Simple
{
  //public class SimpleCommandCreateHandler : IRequestHandler<SimpleCommandCreate, ErrorOr<SimpleAggregate>>
  //{
  //  private readonly TRepo Repo;
  //  public SimpleCommandCreateHandler(TRepo repo)
  //  {
  //    Repo = repo;
  //  }

  //  public async Task<ErrorOr<SimpleAggregate>> Handle(SimpleCommandCreate request, CancellationToken cancellationToken)
  //  {
  //    await Task.CompletedTask;
  //    var item = SimpleAggregate.Create(
  //        title: request.Title,
  //        description: request.Description);
  //    Repo.Add(item);
  //    return item;
  //  }
  //}
}

//var result = TCommand.MakeGenericType(typeof(SimpleAggregate));
//dynamic configurationInstance = Activator.CreateInstance(result);
