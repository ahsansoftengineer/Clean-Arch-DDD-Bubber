namespace Donation.Contracts.Simple
{
  public record SimpleRequestQuery(
    Guid Id,
    string Title);

  public record SimpleRequestChildQuery(
    Guid Id,
    Guid ParentId,
    string Title);
}
