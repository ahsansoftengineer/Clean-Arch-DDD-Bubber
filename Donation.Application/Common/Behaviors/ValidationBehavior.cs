using Donation.Application.Authentication.Commands.Register;
using Donation.Application.Authentication.Common;
using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Donation.Application.Common.Behaviours
{

  public class ValidationRegisterCommandBehavior :
    IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>
  {
    private readonly IValidator<RegisterCommand> validator;

    public ValidationRegisterCommandBehavior(IValidator<RegisterCommand> validator)
    {
      this.validator = validator;
    }
    public async Task<ErrorOr<AuthenticationResult>> Handle(
      RegisterCommand request,
      RequestHandlerDelegate<ErrorOr<AuthenticationResult>> next, 
      CancellationToken cancellationToken)
    {
      var valResult = await validator.ValidateAsync(request, cancellationToken);

      if (valResult.IsValid)
      {
        return await next();
      }

      var errors = valResult.Errors
        .ConvertAll(
          valFailure => Error.Validation(
            valFailure.PropertyName,
            valFailure.ErrorMessage
          )
         );

      return errors;
    }
  }
}
