namespace Donation.Contracts.Simple
{
  public record SimpleRequestCreate(
    string Title,
    string Description);

  public record SimpleRequestChildCreate(
    string Title,
    string Description);
}