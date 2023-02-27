using FluentValidation;

namespace Donation.Application.Menus.Commands.CreateMenu
{
  public class CreateHierarchyCommandValidator : AbstractValidator<CreateHierarchyCommand>
  {
    public CreateHierarchyCommandValidator() {
      RuleFor(x => x.Name).NotEmpty();
      RuleFor(x => x.Description).NotEmpty();
      RuleFor(x => x.Sections).NotEmpty();
    }
  }
}
