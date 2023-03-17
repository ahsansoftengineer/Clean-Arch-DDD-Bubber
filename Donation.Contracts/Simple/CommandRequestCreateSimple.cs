namespace Donation.Contracts.Simple
{
  public record CommandRequestCreateSimple(
    string Title,
    string Description);

  public record CommandRequestCreateSimpleChild(
    Guid ParentId, // you can take it from both url or with in Request Body
    string Title,
    string Description
  );
}