namespace Donation.Contracts.Simple
{
  public record SimpleOption(
    string Title,
    string Description);
  public record SimpleResponseCreate(
    string Id,
    string Title,
    string Description);

  public record SimpleResponseChildCreate(
    string Id,
    string Title,
    string Description,
    string ParentId
    //,SimpleOption Parent
    );

}