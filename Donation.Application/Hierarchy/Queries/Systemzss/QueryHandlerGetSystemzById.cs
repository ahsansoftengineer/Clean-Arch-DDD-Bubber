using Donation.Application.Common.Persistence.Hierarchy;
using Donation.Domain.HierarchyAggregate;
using ErrorOr;
using MediatR;

namespace Donation.Application.Hierarchy.Queries.Systemzss
{
  public class QueryHandlerGetSystemzById : IRequestHandler<SimpleQueryGetById<Systemz>, ErrorOr<Systemz>>
  {
    private readonly ISystemzRepo Repo;

    public QueryHandlerGetSystemzById(ISystemzRepo repo)
    {
      Repo = repo;
    }
    public async Task<ErrorOr<Systemz>>Handle(SimpleQueryGetById<Systemz> request, CancellationToken cancellationToken)
    {
      if (await Repo.GetById(request.Id) is not Systemz data)
      {
        return new[] {
          Domain.Common.Errors.SimpleErrors.IdNotFound("Systemz"),
        };
      }
      return data;
    }
  }
}
