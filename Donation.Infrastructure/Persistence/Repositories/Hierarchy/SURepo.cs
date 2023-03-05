using Donation.Application.Common.Persistence.Hierarchy;
using Donation.Domain.HierarchyAggregate;

namespace Donation.Infrastructure.Persistence.Repositories.Hierarchy
{
  public class SURepo : ISURepo
  {
    private readonly DonationDbContext dbContext;
    public SURepo(DonationDbContext dbContext)
    {
      this.dbContext = dbContext;
    }
    public void Add(SU me)
    {
      dbContext.Add(me);
      dbContext.SaveChanges();
    }
  }
}
