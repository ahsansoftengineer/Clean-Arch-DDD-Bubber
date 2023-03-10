using Donation.Application.Common.Persistence.Hierarchy;
using Donation.Domain.HierarchyAggregate;

namespace Donation.Infrastructure.Persistence.Repositories.Hierarchy
{
  public class OURepo : SimpleRepo<OU>, IOURepo
  {
    public OURepo(DonationDbContext dbContext) : base(dbContext)
    {
    }
  }
}
