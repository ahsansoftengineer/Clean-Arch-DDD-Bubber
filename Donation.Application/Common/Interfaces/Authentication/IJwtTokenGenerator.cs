namespace Donation.Application.Common.Interfaces.Authentication
{
  // Impl in Infrastructure
  public interface IJwtTokenGenerator
  {
    string GenerateToken(Guid userId, string firstName, string lastName);
  }
}
