using Donation.Application.Common.Persistence;
using Donation.Domain.Hierarchy;

namespace Donation.Infrastructure.Persistence.Repositories
{
  public class OrgRepo : SimpleRepository<Org>, IOrgRepo
  {
    public OrgRepo(DonationDbContext dbContext) :base(dbContext) { }
  }
  public class SystemzRepo : SimpleRepository<Systemz>, ISystemzRepo
  {
    public SystemzRepo(DonationDbContext dbContext) : base(dbContext) { }
  }
  //public class BGRepo : SimpleRepository<BG>, IBGRepo
  //{
  //  public BGRepo(DonationDbContext dbContext) : base(dbContext) { }
  //}
  //public class LERepo : SimpleRepository<LE>, ILERepo
  //{
  //  public LERepo(DonationDbContext dbContext): base(dbContext) { }
  //}
  //public class OURepo : SimpleRepository<OU>, IOURepo
  //{
  //  public OURepo(DonationDbContext dbContext): base(dbContext) { }
  //}
  //public class SURepo : SimpleRepository<SU>, ISURepo
  //{
  //  public SURepo(DonationDbContext dbContext) : base(dbContext) { }
  //}
}
