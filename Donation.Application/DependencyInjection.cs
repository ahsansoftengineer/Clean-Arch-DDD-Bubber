using Donation.Application.Servicies.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Donation.Application
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddApplication(this IServiceCollection Services)
    {
      Services.AddScoped<IAuthenticationService, AuthenticationService>();

      return Services;
    }
  }
}
