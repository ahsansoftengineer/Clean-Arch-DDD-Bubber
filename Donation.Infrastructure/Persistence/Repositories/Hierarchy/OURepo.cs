using Donation.Application.Common.Persistence.Hierarchy;
using Donation.Domain.HierarchyAggregate;

namespace Donation.Infrastructure.Persistence.Repositories.Hierarchy
{
  public class OURepo : IOURepo
  {
    private readonly DonationDbContext dbContext;
    public OURepo(DonationDbContext dbContext)
    {
      this.dbContext = dbContext;
    }
    public void Add(OU me)
    {
      dbContext.Add(me);
      dbContext.SaveChanges();
    }
  }
}
