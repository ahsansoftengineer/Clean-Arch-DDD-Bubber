using Donation.Application.Menus.Commands.CreateMenu;
using Donation.Contracts.Menus;
using Donation.Domain.Menu;
using Mapster;
// MenuAggregate
using MenuSection = Donation.Domain.Menu.Entities.MenuSection;
using MenuItem = Donation.Domain.Menu.Entities.MenuItem;

namespace Donation.Api.Common.Mapping
{
  public class MenuMappingConfig : IRegister
  {
    public void Register(TypeAdapterConfig config)
    {
      config.NewConfig<
        (CreateMenuRequest Request, string HostId),  // src area
        CreateHierarchyCommand>() // dest area
        .Map(dest => dest.HostId, src => src.HostId)
        .Map(dest => dest, src => src.Request);

      // Configuration of Mapping MenuResponse to Menu (dest is Menu, src is MenuResponse)
      // There is better way of rewriting it
      config.NewConfig<Menu, MenuResponse>()
        .Map(dest => dest.Id, src => src.Id.Value)
        .Map(dest => dest.AverageRating, src => src.AverageRating.Value)
        .Map(dest => dest.HostId, src => src.HostId.Value)
        .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(dinnerId => dinnerId.Value))
        .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(reviewId => reviewId.Value));

      config.NewConfig<MenuSection, MenuSectionResponse>()
        .Map(dest => dest.Id, src => src.Id.Value);

      config.NewConfig<MenuItem, MenuItemResponse>()
        .Map(dest => dest.Id, src => src.Id.Value);

    }
  }
}
