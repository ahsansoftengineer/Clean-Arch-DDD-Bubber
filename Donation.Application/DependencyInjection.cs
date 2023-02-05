using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Donation.Application
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddApplication(this IServiceCollection Services)
    {
      Services.AddMediatR(typeof(DependencyInjection).Assembly);
      return Services;
    }
  }
}
