namespace Donation.Application.Servicies.Authentication
{
  public record AuthenticationResult(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token
    );
}
