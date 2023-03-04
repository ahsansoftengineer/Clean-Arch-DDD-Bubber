namespace Donation.Contracts.Common
{
  public record CreateSimpleRequest(
    string Title,
    string Description
  );
  public record CreateSimpleChildRequest(
    string Title,
    string Description,
    string ParentId
  );
  public record UpdateSimpleRequest(
    string Id,
    string Title,
    string Description
  );
  public record UpdateSimpleChildRequest(
    string Id,
    string Title,
    string Description,
    string ParentId
  );
}
