using Donation.Domain.Entities;

namespace Donation.Application.Servicies.Authentication
{
    public record AuthenticationResult(
      User User,
      string Token
      );
}
