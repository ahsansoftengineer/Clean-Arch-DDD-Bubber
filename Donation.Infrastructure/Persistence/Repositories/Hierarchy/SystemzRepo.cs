using Donation.Application.Common.Persistence.Hierarchy;
using Donation.Domain.HierarchyAggregate;

namespace Donation.Infrastructure.Persistence.Repositories.Hierarchy
{
  public class SystemzRepo : SimpleRepo<Systemz>, ISystemzRepo
  {
    public SystemzRepo(DonationDbContext dbContext): base(dbContext)
    {
    }
  }
}
