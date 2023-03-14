using Donation.Application.Common.Persistence.Hierarchy;
using Donation.Domain.HierarchyAggregate;
using Donation.Domain.SimpleAggregates;
using Microsoft.EntityFrameworkCore;

namespace Donation.Infrastructure.Persistence.Repositories.Hierarchy
{
  public class OrgRepo : SimpleRepo<Org>, IOrgRepo
  {
    public OrgRepo(DonationDbContext dbContext): base(dbContext) { }

    public async Task<List<Org>> GetAll()
    {
      return await dbContext.Orgs.ToListAsync();
    }

    public async Task<Org> GetById(SimpleValueObject id)
    {
     return await dbContext.Orgs.FirstOrDefaultAsync(x => x.Id == id);
    }
  }
}