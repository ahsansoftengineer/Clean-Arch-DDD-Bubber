using Donation.Domain.Entities;

namespace Donation.Application.Authentication.Common
{
  public record AuthenticationResult(
    User User, 
    string Token
  );
}
