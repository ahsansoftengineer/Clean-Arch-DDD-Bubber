using FluentValidation;

namespace Donation.Application.Hierarchy.Commands
{
  public class CreateOrgCommandValidator : AbstractValidator<CreateOrgCommand>
  {
    public CreateOrgCommandValidator() {
      RuleFor(x => x.Title).NotEmpty();
      RuleFor(x => x.Description).NotEmpty();
    }
  }

  public class CreateSystemzCommandValidator : AbstractValidator<CreateSystemzCommand>
  {
    public CreateSystemzCommandValidator()
    {
      RuleFor(x => x.Title).NotEmpty();
      RuleFor(x => x.Description).NotEmpty();
      RuleFor(x => x.ParentId).NotEmpty();
    }
  }

  public class CreateBGCommandValidator : AbstractValidator<CreateBGCommand>
  {
    public CreateBGCommandValidator()
    {
      RuleFor(x => x.Title).NotEmpty();
      RuleFor(x => x.Description).NotEmpty();
    }
  }

  public class CreateLECommandValidator : AbstractValidator<CreateLECommand>
  {
    public CreateLECommandValidator()
    {
      RuleFor(x => x.Title).NotEmpty();
      RuleFor(x => x.Description).NotEmpty();
      RuleFor(x => x.ParentId).NotEmpty();
    }
  }
  public class CreateOUCommandValidator : AbstractValidator<CreateOUCommand>
  {
    public CreateOUCommandValidator()
    {
      RuleFor(x => x.Title).NotEmpty();
      RuleFor(x => x.Description).NotEmpty();
      RuleFor(x => x.ParentId).NotEmpty();
    }
  }
  public class CreateSUCommandValidator : AbstractValidator<CreateSUCommand>
  {
    public CreateSUCommandValidator()
    {
      RuleFor(x => x.Title).NotEmpty();
      RuleFor(x => x.Description).NotEmpty();
      RuleFor(x => x.ParentId).NotEmpty();
    }
  }
}
