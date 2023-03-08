using FluentValidation;

namespace Donation.Application.Simple
{
  public class SimpleCommandCreateValidator : AbstractValidator<SimpleCommandCreate>
  //where Entity : CreateSimpleCommand<Entity>
  {
    public SimpleCommandCreateValidator()
    {
      RuleFor(x => x.Title).NotEmpty();
      RuleFor(x => x.Title).Length(3, 20);

      RuleFor(x => x.Description).NotEmpty();
      RuleFor(x => x.Description).Length(0, 100);
    }
  }

  public class CreateSimpleChildCommandValidator<Entity> : AbstractValidator<SimpleCommandChildCreate>
  //where Entity: CreateSimpleChildCommand<Entity>
  {
    public CreateSimpleChildCommandValidator()
    {
      RuleFor(x => x.Title).NotEmpty();
      RuleFor(x => x.Title).Length(3, 20);

      RuleFor(x => x.Description).NotEmpty();
      RuleFor(x => x.Description).Length(0, 100);

      RuleFor(x => x.ParentId).NotEmpty();
    }
  }
}
