using Donation.Application.Authentication.Commands.Register;
using Donation.Application.Authentication.Common;
using Donation.Application.Common.Behaviours;
using ErrorOr;
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

      // Adding Behavior with RegisterCommand, AuthenticationResult, ValidationRegisterCommandBehaviorz
      Services.AddScoped<
        IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>,
        ValidationRegisterCommandBehavior
      >();

      // Way 1 Adding RegisterCommand with RegisterCommandValidator without Reflection
      //Services.AddScoped<
      //  IValidator<RegisterCommand>, 
      //  RegisterCommandValidator
      //>();

      // Way 2 Adding RegisterCommand, RegisterCommandValidator with Reflection Required a Package FluentValidation.AspNetCore
      Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

      return Services;
    }
  }
}
