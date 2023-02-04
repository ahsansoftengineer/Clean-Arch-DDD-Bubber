using Donation.Application.Common.Interfaces.Authentication;
using Donation.Application.Common.Persistence;
using Donation.Domain.Entities;
using Donation.Domain.Common;
using ErrorOr;
using System.ComponentModel;

namespace Donation.Application.Servicies.Authentication
{

  public class AuthenticationService : IAuthenticationService
  {
    private readonly IJwtTokenGenerator jwtTokenGenerator;
    private readonly IUserRepository userRepository;

    public AuthenticationService(
      IJwtTokenGenerator jwtTokenGenerator,
      IUserRepository userRepository

      )
    {
      this.jwtTokenGenerator = jwtTokenGenerator;
      this.userRepository = userRepository;
    }
    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
      if (userRepository.GetUserByEmail(email) != null)
      {
        return Domain.Common.Errors.User.DuplicateEmail; 
      }

      // Create user (generate unique Id)
      var user = new User
      {
        FirstName = firstName,
        LastName = lastName,
        Email = email,
        Password = password
      };

      userRepository.Add(user);

      // Create JWT token
      var token = jwtTokenGenerator.GenerateToken(user);
      return new AuthenticationResult(
        user,
        token
      );
    }
    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
      // 1. Validate the User exists 
      if (userRepository.GetUserByEmail(email) is not User user)
      {
        return new[] {
          Domain.Common.Errors.Authentication.InvalidEmail,
          Domain.Common.Errors.Authentication.InvalidPassword,
        };
      }
      // 2. Validate the Password is Correct
      if (user.Password != password)
      {
        return Domain.Common.Errors.Authentication.InvalidPassword;
      }
      // 3. Create JWT token

      var token = jwtTokenGenerator.GenerateToken(user);

      return new AuthenticationResult(
        user,
        token
      );
    }

  }
}
