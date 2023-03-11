using Donation.Application.Common.Persistence.Hierarchy;
using Donation.Domain.Common.Models;
using Donation.Domain.HierarchyAggregate;

namespace Donation.Infrastructure.Persistence.Repositories.Hierarchy
{
  public class OrgRepo : SimpleRepo<Org>, IOrgRepo
  {
    public OrgRepo(DonationDbContext dbContext): base(dbContext) { }
    public void Add(Org me)
    {
      dbContext.Add(me);
      dbContext.SaveChanges();
    }
  }
}