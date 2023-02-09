
namespace Donation.PlayGround
{
  public record User(
    int Id,
    string FirstName,
    string LastName
  );

  public record UserResponse(
    int Id,
    string FirstName,
    string LastName,
    string FullName,
    Guid TraceId
  ) : IValidatable;

  public interface IValidatable
  {
    void Validate()
    {
      Console.WriteLine("Validating...");
    }
  }
}
