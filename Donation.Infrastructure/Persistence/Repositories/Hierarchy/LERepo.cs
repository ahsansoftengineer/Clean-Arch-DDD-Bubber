using Donation.Application.Common.Persistence.Hierarchy;
using Donation.Domain.HierarchyAggregate;

namespace Donation.Infrastructure.Persistence.Repositories.Hierarchy
{
  public class LERepo : ILERepo
  {
    private readonly DonationDbContext dbContext;
    public LERepo(DonationDbContext dbContext)
    {
      this.dbContext = dbContext;
    }
    public void Add(LE me)
    {
      dbContext.Add(me);
      dbContext.SaveChanges();
    }
  }
}
