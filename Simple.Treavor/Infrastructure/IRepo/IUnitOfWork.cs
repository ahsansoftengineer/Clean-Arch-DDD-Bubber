using Simple.Treavor.Infrastructure.Data;

namespace Simple.Treavor.Infrastructure.IRepo
{
    public interface IUnitOfWork : IDisposable
  {
    IGenericRepo<Country> Countries { get; }  // CountryRepo ???
    IGenericRepo<Hotel> Hotels { get; } //

    Task Save();
  }
}
