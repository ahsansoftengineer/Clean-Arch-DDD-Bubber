using Donation.Application.Common.Persistence.Hierarchy;
using Donation.Domain.HierarchyAggregate;
using ErrorOr;
using MediatR;

namespace Donation.Application.Hierarchy.Queries
{
  public class QueryHandlerGetOrgAllwithChilds : IRequestHandler<SimpleQueryGetAllwithChild<Org>, ErrorOr<List<Org>>>
  {
    private readonly IOrgRepo Repo;

    public QueryHandlerGetOrgAllwithChilds(IOrgRepo repo)
    {
      Repo = repo;
    }
    public async Task<ErrorOr<List<Org>>> Handle(
      SimpleQueryGetAllwithChild<Org> request, 
      CancellationToken cancellationToken
    )
    {
      if (await Repo.GetAllwithChilds() is not List<Org> data)
      {
        return new[] {
          Domain.Common.Errors.SimpleErrors.DataNotFound("Org"),
        };
      }
      return data;
    }
  }
}
