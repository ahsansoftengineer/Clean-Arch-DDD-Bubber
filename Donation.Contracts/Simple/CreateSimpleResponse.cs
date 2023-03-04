namespace Donation.Contracts.Common
{
  public record SimpleResponse(
    Guid Id,
    string Title,
    string Description
  );
  public record SimpleChildResponse(
    Guid Id,
    string Title,
    string Description,
    string ParentId,
    Parent Parent
  );
  public record Parent(
    Guid Id,
    string Title
  );
}
