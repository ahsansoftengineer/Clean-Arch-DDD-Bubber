using Donation.Domain.HierarchyAggregate;
using Donation.Domain.SimpleAggregates;

namespace Donation.Application.Common.Persistence.Hierarchy
{
  public interface IOrgRepo : ISimpleRepo<Org>
  {
    Task<Org> GetById(SimpleValueObject id);
  }
}
