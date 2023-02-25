namespace Donation.Contracts.Menus
{
  public record CreateMenuRequest(
    string hostId,
    string Name,
    string Description,
    List<MenuSection> Sections);
  
  public record MenuSection(
    string Name,
    string Description,
    List<MenuItem > Items);

  public record MenuItem(
    string Name, 
    string Description);


}
