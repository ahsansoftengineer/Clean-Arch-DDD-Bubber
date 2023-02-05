using Donation.Domain.Entities;

namespace Donation.Application.Services.Authentication.Common
{
    public record AuthenticationResult(
      User User,
      string Token
      );
}
