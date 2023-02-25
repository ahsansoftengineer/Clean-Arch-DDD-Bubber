using FluentValidation;
using System.Security.Cryptography.X509Certificates;

namespace Donation.Application.Authentication.Commands.Register
{
  public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
  {
    public RegisterCommandValidator() {

      RuleFor(x => x.FirstName).NotEmpty().Length(1, 10);
      RuleFor(x => x.LastName).NotEmpty().MaximumLength(10);
      RuleFor(x => x.Email).NotEmpty().MinimumLength(5);
      RuleFor(x => x.Password).NotEmpty();
    }
  }
}
