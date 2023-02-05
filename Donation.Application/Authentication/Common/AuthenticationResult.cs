using Donation.Domain.Entities;

namespace Donation.Application.Authentication.Common
{
  public record AuthenticationResult(User user, string token)
  {
  }
}
