using Donation.Application.Common.Persistence.Hierarchy;
using Donation.Domain.HierarchyAggregate;

namespace Donation.Infrastructure.Persistence.Repositories.Hierarchy
{
  public class BGRepo : SimpleRepo<BG>, IBGRepo
  {
    public BGRepo(DonationDbContext dbContext) : base(dbContext)
    {
    }
  }
}
