using Donation.Application.Common.Persistence;
namespace Donation.Infrastructure.Persistence.Repositories
{
  public class SimpleRepo<TEntity> : ISimpleRepo<TEntity>
  {
    protected readonly DonationDbContext dbContext;

    public SimpleRepo(DonationDbContext dbContext)
    {
      this.dbContext = dbContext;
    }
    public void Add(TEntity me)
    {
      dbContext.Add(me);
      dbContext.SaveChanges();
    }
  }
}
