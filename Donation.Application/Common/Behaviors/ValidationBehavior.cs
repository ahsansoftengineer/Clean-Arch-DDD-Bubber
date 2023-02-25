using ErrorOr;
using FluentValidation;
using MediatR;

namespace Donation.Application.Common.Behaviours
{

  public class ValidationBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse> 
      where TRequest : IRequest<TResponse>
      where TResponse : IErrorOr
  {
    private readonly IValidator<TRequest>? validator;

    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
      this.validator = validator;
    }
    public async Task<TResponse> Handle(
      TRequest request,
      RequestHandlerDelegate<TResponse> next,
      CancellationToken cancellationToken
      )
    {
      if (validator is null) return await next();

      var valResult = await validator.ValidateAsync(request, cancellationToken);

      if (valResult.IsValid)  return await next();

      var errors = valResult.Errors
        .ConvertAll(
          valFailure => Error.Validation(
            valFailure.PropertyName,
            valFailure.ErrorMessage
          )
         );

      // Compiler Doesn't know there is implicit converter to ErrorOr Object
      // dynamic use runtime to check to convert list of object to ErrorOr Object
      return (dynamic)errors;
    }
  }
}
