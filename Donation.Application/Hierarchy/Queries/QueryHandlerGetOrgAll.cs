using Donation.Application.Common.Persistence.Hierarchy;
using Donation.Domain.HierarchyAggregate;
using ErrorOr;
using MediatR;

namespace Donation.Application.Hierarchy.Queries
{
  public class QueryHandlerGetOrgAll : IRequestHandler<SimpleQueryGetAll<Org>, ErrorOr<List<Org>>>
  {
    private readonly IOrgRepo Repo;

    public QueryHandlerGetOrgAll(IOrgRepo repo)
    {
      Repo = repo;
    }
    public async Task<ErrorOr<List<Org>>> Handle(
      SimpleQueryGetAll<Org> request, 
      CancellationToken cancellationToken
    )
    {
      if (await Repo.GetAll() is not List<Org> data)
      {
        return new[] {
          Domain.Common.Errors.SimpleErrors.DataNotFound("Org"),
        };
      }
      return data;
    }
  }
}
