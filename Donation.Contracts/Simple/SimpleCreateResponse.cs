namespace Donation.Contracts.Simple
{
  public record SimpleOption(
    string Title,
    string Description);
  public record SimpleCreateResponse(
    string Id,
    string Title,
    string Description);

  public record SimpleChildCreateResponse(
    string Id,
    string Title,
    string Description,
    string ParentId
    //,SimpleOption Parent
    );

}