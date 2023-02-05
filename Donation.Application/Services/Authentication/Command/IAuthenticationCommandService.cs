using Donation.Application.Services.Authentication.Common;
using ErrorOr;

namespace Donation.Application.Services.Authentication.Command
{
    public interface IAuthenticationCommandService
    {
        ErrorOr<AuthenticationResult> Register(
          string firstName,
          string lastName,
          string email,
          string password
        );
    }
}
