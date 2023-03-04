using Donation.Domain.Hierarchy;

namespace Donation.Infrastructure.Persistence.Repositories
{
  public class OrgRepository : SimpleRepository<Org>
  {
    public OrgRepository(DonationDbContext dbContext) :base(dbContext) { }
  }
  public class SystemzRepo : SimpleRepository<Systemz>
  {
    public SystemzRepo(DonationDbContext dbContext): base(dbContext) { }
  }
  public class BGRepo : SimpleRepository<BG>
  {
    public BGRepo(DonationDbContext dbContext) : base(dbContext) { }
  }
  public class LERepo : SimpleRepository<LE>
  {
    public LERepo(DonationDbContext dbContext): base(dbContext) { }
  }
  public class OURepo : SimpleRepository<OU>
  {
    public OURepo(DonationDbContext dbContext): base(dbContext) { }
  }
  public class SURepo : SimpleRepository<SU>
  {
    public SURepo(DonationDbContext dbContext) : base(dbContext) { }
  }
}
