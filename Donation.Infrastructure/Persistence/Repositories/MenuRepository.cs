using Donation.Application.Common.Persistence;
using Donation.Domain.Menu;

namespace Donation.Infrastructure.Persistence.Repositories
{
  public class MenuRepository : IMenuRepository
  {
    private readonly DonationDbContext dbContext;

    public MenuRepository(DonationDbContext dbContext)
    {
      this.dbContext = dbContext;
    }
    public void Add(Menu menu)
    {
      //dbContext.Menus.Add(menu);
      dbContext.Add(menu);
      dbContext.SaveChanges();
    }
  }
}
