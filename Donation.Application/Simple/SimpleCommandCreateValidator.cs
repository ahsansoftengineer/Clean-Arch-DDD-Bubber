using FluentValidation;

namespace Donation.Application.Simple
{
  public class SimpleCommandValidatorCreate<TEntity>: AbstractValidator<SimpleCommandCreate<TEntity>>
  {
    public SimpleCommandValidatorCreate()
    {
      RuleFor(x => x.Title).NotEmpty();
      RuleFor(x => x.Title).Length(5, 20);

      RuleFor(x => x.Description).NotEmpty();
      RuleFor(x => x.Description).Length(0, 100);
    }
  }

  public class SimpleCommandValidatorChildCreate<TEntity> : AbstractValidator<SimpleCommandChildCreate<TEntity>>
  {
    public SimpleCommandValidatorChildCreate()
    {
      RuleFor(x => x.Title).NotEmpty();
      RuleFor(x => x.Title).Length(3, 20);

      RuleFor(x => x.Description).NotEmpty();
      RuleFor(x => x.Description).Length(0, 100);

      RuleFor(x => x.ParentId).NotEmpty();
    }
  }
}
