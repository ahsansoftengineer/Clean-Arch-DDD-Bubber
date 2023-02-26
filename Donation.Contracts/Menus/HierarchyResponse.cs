using System.Reflection;

namespace Donation.Contracts.Menus
{
  public record SelectResponse(
    Guid Id, 
    string Title);
  public record SimpleResponse(
    Guid Id, 
    string Title, 
    string Description);
  public record ChildResponse(
    Guid Id,
    string Title,
    string Description,
    Guid parentId,
    SelectResponse Parent);
}
