using Donation.Application.Common.Interfaces.Authentication;
using Donation.Application.Common.Persistence;
using Donation.Domain.Entities;
using Donation.Domain.Common;
using ErrorOr;
using System.ComponentModel;
using Donation.Application.Services.Authentication.Common;

namespace Donation.Application.Services.Authentication.Query
{

    public class AuthenticationQueryService : IAuthenticationQueryService
    {
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IUserRepository userRepository;

        public AuthenticationQueryService(
          IJwtTokenGenerator jwtTokenGenerator,
          IUserRepository userRepository

          )
        {
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.userRepository = userRepository;
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
