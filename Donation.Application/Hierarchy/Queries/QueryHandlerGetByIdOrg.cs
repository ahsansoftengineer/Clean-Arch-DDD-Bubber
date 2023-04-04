using Donation.Application.Common.Persistence.Hierarchy;
using Donation.Domain.HierarchyAggregate;
using ErrorOr;
using MediatR;

namespace Donation.Application.Hierarchy.Queries
{
  public class QueryHandlerGetByIdOrg : IRequestHandler<SimpleQueryGetById<Org>, ErrorOr<Org>>
  {
    private readonly IOrgRepo Repo;

    public QueryHandlerGetByIdOrg(IOrgRepo repo)
    {
      Repo = repo;
    }
    public async Task<ErrorOr<Org>> Handle(SimpleQueryGetById<Org> request, CancellationToken cancellationToken)
    {
      if (await Repo.GetById(request.Id) is not Org data)
      {
        return new[] {
          Domain.Common.Errors.SimpleErrors.IdNotFound("Org"),
        };
      }
      return data;
    }
  }
}
