using Donation.Domain.Hierarchy;
using Donation.Domain.Menu;

namespace Donation.Application.Common.Persistence
{
  public interface IOrgRepo
  {
    void Add(Org me);
  }
  public interface ISystemzRepo
  {
    void Add(Systemz me);
  }
  public interface IBusinessGroupRepo
  {
    void Add(BusinessGroup me);
  }
  public interface ILegalEntityRepo
  {
    void Add(LegalEntity me);
  }
  public interface IOperatingUnitRepo
  {
    void Add(OperatingUnit me);
  }
  public interface ISubUnitRepo
  {
    void Add(SubUnit me);
  }
}
