using Donation.Domain.Entities;

namespace Donation.Application.Common.Interfaces.Authentication
{
  // Impl in Infrastructure
  public interface IJwtTokenGenerator
  {
    string GenerateToken(User user);
  }
}
