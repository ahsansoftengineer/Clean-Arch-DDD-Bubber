using Donation.Application.Common.Persistence.Hierarchy;
using Donation.Domain.HierarchyAggregate;
using ErrorOr;
using MediatR;

namespace Donation.Application.Hierarchy.Queries.Systemzss
{
  public class QueryHandlerGetSystemzAll : IRequestHandler<SimpleQueryGetAll<Systemz>, ErrorOr<List<Systemz>>>
  {
    private readonly ISystemzRepo Repo;

    public QueryHandlerGetSystemzAll(ISystemzRepo repo)
    {
      Repo = repo;
    }
    public async Task<ErrorOr<List<Systemz>>> Handle(
      SimpleQueryGetAll<Systemz> request, 
      CancellationToken cancellationToken
    )
    {
      if (await Repo.GetAll() is not List<Systemz> data)
      {
        return new[] {
          Domain.Common.Errors.SimpleErrors.DataNotFound("Org"),
        };
      }
      return data;
    }
  }
}
