using Donation.Domain.Common.Models.Hierarchy;
using FluentValidation;

namespace Donation.Application.Common.Commands
{
  public class CreateSimpleCommandValidator<Entityz> : AbstractValidator<CreateSimpleCommand<Entityz>>
    where Entityz : AggregateRootBaseSimpleParent
  {
    public CreateSimpleCommandValidator() {
      RuleFor(x => x.Title).NotEmpty();
      RuleFor(x => x.Description).NotEmpty();
    }
  }

  public class CreateSimpleChildCommandValidator<Entityz> : AbstractValidator<CreateSimpleChildCommand<Entityz>>
    where Entityz : AggregateRootBaseSimpleParent
  {
    public CreateSimpleChildCommandValidator()
    {
      RuleFor(x => x.Title).NotEmpty();
      RuleFor(x => x.Description).NotEmpty();
      RuleFor(x => x.ParentId).NotEmpty();
    }
  }
}
