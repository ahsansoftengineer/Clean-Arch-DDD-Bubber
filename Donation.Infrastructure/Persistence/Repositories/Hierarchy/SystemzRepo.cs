using Donation.Application.Common.Persistence.Hierarchy;
using Donation.Domain.HierarchyAggregate;

namespace Donation.Infrastructure.Persistence.Repositories.Hierarchy
{
  public class SystemzRepo : ISystemzRepo
  {
    private readonly DonationDbContext dbContext;
    public SystemzRepo(DonationDbContext dbContext)
    {
      this.dbContext = dbContext;
    }
    public void Add(Systemz me)
    {
      dbContext.Add(me);
      dbContext.SaveChanges();
    }
  }
}
