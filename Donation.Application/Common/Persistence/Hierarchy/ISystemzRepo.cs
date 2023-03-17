using Donation.Domain.HierarchyAggregate;
using Donation.Domain.SimpleAggregates;

namespace Donation.Application.Common.Persistence.Hierarchy
{
  public interface ISystemzRepo : ISimpleRepo<Systemz>
  {
    Task<Systemz> GetById(SimpleValueObject id);
    Task<Systemz> GetByIdwithParent(SimpleValueObject id);
    Task<List<Systemz>> GetAll();
    Task<List<Systemz>> GetAllwithParent();
  }
}
