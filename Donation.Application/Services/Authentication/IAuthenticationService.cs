using Donation.Application.Common.Errors;
using FluentResults;

namespace Donation.Application.Servicies.Authentication
{
  public interface IAuthenticationService
  {
    Result<AuthenticationResult> Register(
      string firstName,
      string lastName,
      string email,
      string password
    );
    AuthenticationResult Login(string email, string password);
  }
}
