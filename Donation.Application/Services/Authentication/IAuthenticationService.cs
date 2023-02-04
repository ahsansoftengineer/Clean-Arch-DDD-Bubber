using Donation.Application.Common.Errors;
using OneOf;

namespace Donation.Application.Servicies.Authentication
{
    public interface IAuthenticationService
    {
        OneOf<AuthenticationResult, DuplicationEmailError> Register(
          string firstName,
          string lastName,
          string email,
          string password
        );
        AuthenticationResult Login(string email, string password);
    }
}
