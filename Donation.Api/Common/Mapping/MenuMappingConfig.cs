using Donation.Application.Menus.Commands.CreateMenu;
using Donation.Contracts.Menus;
using Mapster;

namespace Donation.Api.Common.Mapping
{
  public class MenuMappingConfig : IRegister
  {
    public void Register(TypeAdapterConfig config)
    {
      config.NewConfig<
        (CreateMenuRequest Request, string HostId),  // src area
        CreateMenuCommand>() // dest area
        .Map(dest => dest.HostId, src => src.HostId)
        .Map(dest => dest, src => src.Request);

    }
  }
}
