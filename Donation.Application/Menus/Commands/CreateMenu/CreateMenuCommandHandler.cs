using Donation.Application.Common.Persistence;
using Donation.Domain.Host.ValueObjects;
using Donation.Domain.Menu;
using Donation.Domain.Menu.Entities;
using ErrorOr;
using MediatR;

namespace Donation.Application.Menus.Commands.CreateMenu
{
  public class CreateHierarchyCommandHandler : IRequestHandler<CreateHierarchyCommand, ErrorOr<Menu>>
  {
    private readonly IMenuRepository _menuRepository;

    public CreateHierarchyCommandHandler(IMenuRepository menuRepository)
    {
      _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Menu>> Handle(CreateHierarchyCommand request, CancellationToken cancellationToken)
    {
      await Task.CompletedTask;
      // 1. Create Menu
      var menu = Menu.Create(
          hostId: HostId.CreateUnique(),//HostId.Create(request.HostId),
          name: request.Name,
          description: request.Description,
          sections: request.Sections.ConvertAll(sections => MenuSection.Create(
              name: sections.Name,
              description: sections.Description,
              items: sections.Items.ConvertAll(items => MenuItem.Create(
                  name: items.Name,
                  description: items.Description)))));
      // 2. Persist Menu
      _menuRepository.Add(menu);
      // 3. Return Menu
      return menu;
    }
  }
}
