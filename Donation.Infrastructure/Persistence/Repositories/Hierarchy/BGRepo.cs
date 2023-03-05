using Donation.Application.Common.Persistence.Hierarchy;
using Donation.Domain.HierarchyAggregate;

namespace Donation.Infrastructure.Persistence.Repositories.Hierarchy
{
  public class BGRepo : IBGRepo
  {
    private readonly DonationDbContext dbContext;
    public BGRepo(DonationDbContext dbContext)
    {
      this.dbContext = dbContext;
    }
    public void Add(BG me)
    {
      dbContext.Add(me);
      dbContext.SaveChanges();
    }
  }
}
