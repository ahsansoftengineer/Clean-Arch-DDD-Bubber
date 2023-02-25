using Donation.Application.Common.Persistence;
using Donation.Domain.Hierarchy;

namespace Donation.Infrastructure.Persistence.Repositories
{
  public class OrgRepository : IOrgRepo
  {
    private readonly DonationDbContext dbContext;

    public OrgRepository(DonationDbContext dbContext)
    {
      this.dbContext = dbContext;
    }
    public void Add(Org menu)
    {
      //dbContext.Menus.Add(menu);
      dbContext.Add(menu);
      dbContext.SaveChanges();
    }
  }
  public class SystemzRepo : ISystemzRepo
  {
    private readonly DonationDbContext dbContext;

    public SystemzRepo(DonationDbContext dbContext)
    {
      this.dbContext = dbContext;
    }
    public void Add(Systemz bg)
    {
      dbContext.Add(bg);
      dbContext.SaveChanges();
    }
  }
  public class BusinessGroupRepo : IBusinessGroupRepo
  {
    private readonly DonationDbContext dbContext;

    public BusinessGroupRepo(DonationDbContext dbContext)
    {
      this.dbContext = dbContext;
    }
    public void Add(BusinessGroup bg)
    {
      dbContext.Add(bg);
      dbContext.SaveChanges();
    }
  }

  public class LegalEntityRepo : ILegalEntityRepo
  {
    private readonly DonationDbContext dbContext;

    public LegalEntityRepo(DonationDbContext dbContext)
    {
      this.dbContext = dbContext;
    }
    public void Add(LegalEntity le)
    {
      dbContext.Add(le);
      dbContext.SaveChanges();
    }
  }
  public class OperatinUnitRepo : IOperatingUnitRepo
  {
    private readonly DonationDbContext dbContext;

    public OperatinUnitRepo(DonationDbContext dbContext)
    {
      this.dbContext = dbContext;
    }
    public void Add(OperatingUnit ou)
    {
      dbContext.Add(ou);
      dbContext.SaveChanges();
    }
  }
  public class SubUnitRepo : ISubUnitRepo
  {
    private readonly DonationDbContext dbContext;

    public SubUnitRepo(DonationDbContext dbContext)
    {
      this.dbContext = dbContext;
    }
    public void Add(SubUnit su)
    {
      dbContext.Add(su);
      dbContext.SaveChanges();
    }
  }
}
