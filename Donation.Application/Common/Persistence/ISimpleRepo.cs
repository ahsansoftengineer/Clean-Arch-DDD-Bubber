namespace Donation.Application.Common.Persistence
{
  public interface ISimpleRepo<TEntity>
  {
    void Add(TEntity menu);
  }
}
