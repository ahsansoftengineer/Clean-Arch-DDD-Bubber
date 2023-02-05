using Donation.Application.Services.Authentication.Common;
using ErrorOr;

namespace Donation.Application.Services.Authentication.Query
{
    public interface IAuthenticationQueryService
    {
        ErrorOr<AuthenticationResult> Login(string email, string password);
    }
}
