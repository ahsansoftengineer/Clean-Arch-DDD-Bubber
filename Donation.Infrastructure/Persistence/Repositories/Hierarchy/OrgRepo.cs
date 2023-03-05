using Donation.Application.Common.Persistence.Hierarchy;
using Donation.Domain.HierarchyAggregate;

namespace Donation.Infrastructure.Persistence.Repositories.Hierarchy
{
  public class OrgRepo : IOrgRepo
  {
    private readonly DonationDbContext dbContext;
    public OrgRepo(DonationDbContext dbContext)
    {
      this.dbContext = dbContext;
    }
    public void Add(Org me)
    {
      dbContext.Add(me);
      dbContext.SaveChanges();
    }
  }
}
