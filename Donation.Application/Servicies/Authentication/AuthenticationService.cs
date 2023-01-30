using Donation.Application.Common.Interfaces.Authentication;

namespace Donation.Application.Servicies.Authentication
{



    public class AuthenticationService : IAuthenticationService
  {
    private readonly IJwtTokenGenerator jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
      this.jwtTokenGenerator = jwtTokenGenerator;
    }
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
      // Check if user already exists

      // Create user (generate unique Id)

      // Create JWT token

      Guid userId = Guid.NewGuid();

      var token = jwtTokenGenerator.GenerateToken(userId, firstName, lastName);
      return new AuthenticationResult(
        userId,
        firstName,
        lastName,
        email,
        token
      );
    }
    public AuthenticationResult Login(string email, string password)
    {
      return new AuthenticationResult(
        Guid.NewGuid(),
        "firstName",
        "lastName",
        email,
        "token"
      );
    }


  }
}
