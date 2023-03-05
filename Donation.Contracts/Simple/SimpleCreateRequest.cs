namespace Donation.Contracts.Simple
{
  public record SimpleCreateRequest(
    string Title,
    string Description);

  public record SimpleChildCreateRequest(
    string Title,
    string Description,
    string ParentId);
}