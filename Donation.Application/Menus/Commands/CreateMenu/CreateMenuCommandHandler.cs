using Donation.Domain.Host.ValueObjects;
using Donation.Domain.Menu;
using Donation.Domain.Menu.Entities;
using ErrorOr;
using MediatR;

namespace Donation.Application.Menus.Commands.CreateMenu
{
  public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
  {
    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
      await Task.CompletedTask;

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

      //_menuRepository.Add(menu);

      return menu;
    }
  }
}
