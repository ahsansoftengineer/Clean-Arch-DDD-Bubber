namespace Donation.Contracts.Simple
{
  public record SimpleResponseQuery(
    string Id,
    string Title,
    string Description,
    string ParentId
    //,SimpleOption Parent
    );

}