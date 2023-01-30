using Donation.Application.Common.Interfaces.Authentication;
using Donation.Application.Common.Services;
using Donation.Infrastructure.Authentication;
using Donation.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Donation.Infrastructure
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddInfrastructure(
      this IServiceCollection Services, 
      ConfigurationManager Configuration
    )
    {
      Services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));
      // 1. Interface are Coming From Application Layer
      // 2. Classes Coming From Infrastructure
      Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
      Services.AddScoped<IDateTimeProvider, DateTimeProvider>();

      return Services;
    }
  }
}
