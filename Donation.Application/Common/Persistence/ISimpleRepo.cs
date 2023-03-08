namespace Donation.Application.Common.Persistence
{
  // Base Interface
  public interface ISimpleRepo<TEntity>
  {
    void Add(TEntity menu);
  }
}
