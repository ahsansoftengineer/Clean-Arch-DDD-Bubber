using Donation.Application.Common.Persistence.Hierarchy;
using Donation.Domain.HierarchyAggregate;

namespace Donation.Infrastructure.Persistence.Repositories.Hierarchy
{
  public class SURepo : SimpleRepo<SU>, ISURepo
  {
    public SURepo(DonationDbContext dbContext) : base(dbContext) { }
  }
}
