using Donation.Application.Menus.Commands.CreateMenu;
using Donation.Contracts.Menus;
using Mapster;
// MenuAggregate
using MenuSection = Donation.Domain.Menu.Entities.MenuSection;
using MenuItem = Donation.Domain.Menu.Entities.MenuItem;
using Donation.Domain.Hierarchy;

namespace Donation.Api.Common.Mapping
{
  public class HierarchyMappingConfig : IRegister
  {
    public void Register(TypeAdapterConfig config)
    {
      config.NewConfig<
        (CreateMenuRequest Request, string HostId),  // src area
        CreateMenuCommand>() // dest area
        .Map(dest => dest.HostId, src => src.HostId)
        .Map(dest => dest, src => src.Request);

      // Configuration of Mapping MenuResponse to Menu (dest is Menu, src is MenuResponse)
      // There is better way of rewriting it
      config.NewConfig<Org, SimpleResponse>()
        .Map(dest => dest.Id, src => src.Id.Value);
      config.NewConfig<Systemz, ChildResponse>()
        .Map(dest => dest.Id, src => src.Id.Value)
        .Map(dest => dest.Id, src => src.Id.Value);

      config.NewConfig<MenuSection, MenuSectionResponse>()
        .Map(dest => dest.Id, src => src.Id.Value);

      config.NewConfig<MenuItem, MenuItemResponse>()
        .Map(dest => dest.Id, src => src.Id.Value);

    }
  }
}
