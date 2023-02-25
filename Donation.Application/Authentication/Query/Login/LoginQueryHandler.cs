using Donation.Application.Authentication.Common;
using Donation.Application.Common.Interfaces.Authentication;
using Donation.Application.Common.Persistence;
using Donation.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Donation.Application.Authentication.Query.Login
{
  internal class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
  {
    private readonly IJwtTokenGenerator jwtTokenGenerator;
    private readonly IUserRepository userRepository;

    public LoginQueryHandler(
      IJwtTokenGenerator jwtTokenGenerator,
      IUserRepository userRepository

      )
    {
      this.jwtTokenGenerator = jwtTokenGenerator;
      this.userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
      await Task.CompletedTask;
      // 1. Validate the User exists 
      if (userRepository.GetUserByEmail(query.Email) is not User user)
      {
        return new[] {
          Domain.Common.Errors.Authentication.InvalidEmail,
          Domain.Common.Errors.Authentication.InvalidPassword,
        };
      }
      // 2. Validate the Password is Correct
      if (user.Password != query.Password)
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
