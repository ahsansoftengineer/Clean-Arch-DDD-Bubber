using Donation.Domain.Hierarchy;

namespace Donation.Application.Common.Persistence
{
  public interface IGenericRepo<IEntityz>
  {
    void Add(IEntityz me);
  }
  public interface IOrgRepo : IGenericRepo<Org>
  {
  }
  public interface ISystemzRepo : IGenericRepo<Systemz>
  {
  }
  public interface IBGRepo : IGenericRepo<BG>
  {
  }
  public interface ILERepo : IGenericRepo<LE>
  {
  }
  public interface IOURepo : IGenericRepo<OU>
  {
  }
  public interface ISURepo : IGenericRepo<SU>
  {
  }
}
