using Donation.Application.Common.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Donation.Application
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddApplication(this IServiceCollection Services)
    {
      Services.AddMediatR(typeof(DependencyInjection).Assembly);

      // Generic Adding Services
      Services.AddScoped(
        typeof(IPipelineBehavior<,>),
        typeof(ValidationBehavior<,>)
      );

      Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

      return Services;
    }
  }
}
