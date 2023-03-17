using Donation.Application.Common.Persistence.Hierarchy;
using Donation.Domain.HierarchyAggregate;
using ErrorOr;
using MediatR;

namespace Donation.Application.Hierarchy.Queries.Systemzss
{
  public class QueryHandlerGetSystemzByIdwithParent : IRequestHandler<SimpleQueryGetByIdwithParent<Systemz>, ErrorOr<Systemz>>
  {
    private readonly ISystemzRepo Repo;

    public QueryHandlerGetSystemzByIdwithParent(ISystemzRepo repo)
    {
      Repo = repo;
    }
    public async Task<ErrorOr<Systemz>>Handle(SimpleQueryGetByIdwithParent<Systemz> request, CancellationToken cancellationToken)
    {
      if (await Repo.GetByIdwithParent(request.Id) is not Systemz data)
      {
        return new[] {
          Domain.Common.Errors.SimpleErrors.IdNotFound("Systemz"),
        };
      }
      return data;
    }
  }
}
