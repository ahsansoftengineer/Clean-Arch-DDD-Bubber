using Donation.Application.Common.Persistence;

namespace Donation.Infrastructure.Persistence.Repositories
{
  public class SimpleRepository<Entityz> : IGenericRepo<Entityz>
  {
    protected readonly DonationDbContext dbContext;
    public SimpleRepository(DonationDbContext dbContext)
    {
      this.dbContext = dbContext;
    }
    public void Add(Entityz me)
    {
      //dbContext.Menus.Add(menu);
      Console.WriteLine(me);
      dbContext.Add(me);
      dbContext.SaveChanges();
    }
  }
}
