using Donation.Domain.Common.Models;
using Donation.Domain.Menu.ValueObjects;

namespace Donation.Domain.Menu.Entities
{
  public sealed class MenuSection : Entity<MenuSectionId>
  {
    private readonly List<MenuItem> items = new();
    public string Name { get; }
    public string Description { get; }
    IReadOnlyList<MenuItem> Items => items.AsReadOnly(); // AS per need .ToList();
    private MenuSection(
      MenuSectionId menuSectionId,
      string name, 
      string description): base(menuSectionId)
    {
      Name = name;
      Description = description;
    }
    public static MenuSection Create(
      string name,
      string description)
    {
      return new(
        MenuSectionId.CreateUnique(),
        name,
        description);
    }
  }
}
