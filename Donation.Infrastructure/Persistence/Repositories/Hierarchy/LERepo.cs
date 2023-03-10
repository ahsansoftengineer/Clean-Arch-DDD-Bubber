using Donation.Application.Common.Persistence.Hierarchy;
using Donation.Domain.HierarchyAggregate;

namespace Donation.Infrastructure.Persistence.Repositories.Hierarchy
{
  public class LERepo : SimpleRepo<LE>, ILERepo
  {
    public LERepo(DonationDbContext dbContext) : base(dbContext)
    {
    }
  }
}
