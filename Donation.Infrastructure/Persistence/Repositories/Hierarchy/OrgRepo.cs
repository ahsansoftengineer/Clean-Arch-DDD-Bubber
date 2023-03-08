using Donation.Application.Common.Persistence.Hierarchy;
using Donation.Domain.HierarchyAggregate;

namespace Donation.Infrastructure.Persistence.Repositories.Hierarchy
{
  public class OrgRepo : SimpleRepo<Org>, IOrgRepo
  {
    public OrgRepo(DonationDbContext dbContext): base(dbContext) { }
  }
}