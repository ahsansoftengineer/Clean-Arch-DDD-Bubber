using Simple.Treavor.Infrastructure.Context;
using Simple.Treavor.Infrastructure.Data;
using Simple.Treavor.Infrastructure.IRepo;

namespace Simple.Treavor.Infrastructure.Repo
{
    public class UnitOfWork : IUnitOfWork
  {
    private readonly DatabaseContext _context;
    private IGenericRepo<Country> _countries;
    private IGenericRepo<Hotel> _hotel;

    public UnitOfWork(DatabaseContext context)
    {
      _context = context;
    }
    // ??= C# 9 Short-hand Syntax
    public IGenericRepo<Country> Countries => _countries ??= new GenericRepo<Country>(_context);
    public IGenericRepo<Hotel> Hotels => _hotel ??= new GenericRepo<Hotel>(_context);


    public void Dispose()
    {
      _context.Dispose();
      GC.SuppressFinalize(this);
    }

    public async Task Save()
    {
      await _context.SaveChangesAsync();  
    }
  }
}
