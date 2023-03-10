namespace Donation.Contracts.Simple
{
  public record SimpleRequestCreate(
    string Title,
    string Description);

  public record SimpleRequestChildCreate(
    Guid ParentId, // you can take it from both url or with in Request Body
    string Title,
    string Description
  );
}