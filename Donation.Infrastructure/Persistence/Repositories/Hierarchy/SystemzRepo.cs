using Donation.Application.Common.Persistence.Hierarchy;
using Donation.Domain.HierarchyAggregate;
using Donation.Domain.SimpleAggregates;
using Microsoft.EntityFrameworkCore;

namespace Donation.Infrastructure.Persistence.Repositories.Hierarchy
{
  public class SystemzRepo : SimpleRepo<Systemz>, ISystemzRepo
  {
    public SystemzRepo(DonationDbContext dbContext) : base(dbContext) { }

    public async Task<List<Systemz>> GetAll()
    {
      return await dbContext.Systemzs.ToListAsync();
    }
    public async Task<Systemz> GetById(SimpleValueObject id)
    {
      return await dbContext.Systemzs.FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<Systemz> GetByIdwithParent(SimpleValueObject id)
    {
      return await dbContext.Systemzs
        .Include(s => s.Org)
        .FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<List<Systemz>> GetAllwithParent()
    {
      //throw new NotImplementedException();
      return await dbContext.Systemzs
        .Include(s => s.Org)
        .AsNoTracking()
        .ToListAsync();
    }


  }
}
