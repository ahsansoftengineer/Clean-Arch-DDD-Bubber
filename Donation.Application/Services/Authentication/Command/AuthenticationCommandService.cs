using Donation.Application.Common.Interfaces.Authentication;
using Donation.Application.Common.Persistence;
using Donation.Application.Services.Authentication.Common;
using Donation.Domain.Entities;
using ErrorOr;

namespace Donation.Application.Services.Authentication.Command
{

    public class AuthenticationCommandService : IAuthenticationCommandService
    {
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IUserRepository userRepository;

        public AuthenticationCommandService(
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
    }
}
