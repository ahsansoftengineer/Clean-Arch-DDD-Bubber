using Donation.Application.Common.Commands;
using Donation.Application.Common.Persistence;
using Donation.Domain.Common.Models;
using Donation.Domain.Common.Models.Hierarchy;
using ErrorOr;
using MediatR;

namespace Donation.Application.Hierarchy.Commands
{
  public class CreateSimpleChildCommandHandler<IRepoz, Entityz> : IRequestHandler<CreateSimpleChildCommand<Entityz>, ErrorOr<Entityz>>
     where IRepoz : IGenericRepo<Entityz>
     where Entityz : AggregateRootBaseSimpleChild
  {
    private readonly IRepoz Repo;
    public CreateSimpleChildCommandHandler(IRepoz repo)
    {
      this.Repo = repo;
    }
    public async Task<ErrorOr<Entityz>> Handle(CreateSimpleChildCommand<Entityz> request, CancellationToken cancellationToken)
    {
      await Task.CompletedTask;
      var result = AggregateRootBaseSimpleChild.Create(
        title: request.Title,
        description: request.Description,
        parentId: GenericValueObjectId.Create(request.ParentId)
      );

      Repo.Add(result as Entityz);

      return result as Entityz;
    }
  }
}
