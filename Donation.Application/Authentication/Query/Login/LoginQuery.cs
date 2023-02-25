using Donation.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Donation.Application.Authentication.Query.Login
{
  public record LoginQuery(
      string Email,
      string Password
    ) : IRequest<ErrorOr<AuthenticationResult>>;
}
