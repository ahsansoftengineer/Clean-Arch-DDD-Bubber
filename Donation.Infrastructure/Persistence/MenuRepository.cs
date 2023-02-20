using Donation.Application.Common.Persistence;
using Donation.Domain.Menu;

namespace Donation.Infrastructure.Persistence
{
  public class MenuRepository : IMenuRepository
  {
    private static readonly List<Menu> _menus = new List<Menu>();
    public void Add(Menu menu)
    {
      _menus.Add(menu);
    }
  }
}
