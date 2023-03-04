using Donation.Application.Common.Persistence;
using Donation.Domain.Common.Models.Hierarchy;
using ErrorOr;
using MediatR;

namespace Donation.Application.Common.Commands
{
  public class CreateSimpleCommandHandler<IRepoz, Entityz> : IRequestHandler<CreateSimpleCommand<Entityz>, ErrorOr<Entityz>>
     where IRepoz : IGenericRepo<Entityz>
     where Entityz : AggregateRootBaseSimpleParent
  {
    protected readonly IRepoz Repo;

    public CreateSimpleCommandHandler(IRepoz repo)
    {
      this.Repo = repo;
    }
    public async Task<ErrorOr<Entityz>> Handle(CreateSimpleCommand<Entityz> request, CancellationToken cancellationToken)
    {
      await Task.CompletedTask;
      var result = AggregateRootBase.Create(
        title: request.Title,
        description: request.Description);

      Repo.Add(result as Entityz);

      return result as Entityz;
    }
  }
}
