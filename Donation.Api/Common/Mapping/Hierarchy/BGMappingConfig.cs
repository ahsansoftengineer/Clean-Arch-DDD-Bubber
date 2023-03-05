using Donation.Application.Hierarchy.Commands;
using Donation.Contracts.Simple;
using Donation.Domain.HierarchyAggregate;
using Mapster;
// BGAggregate

namespace Donation.Api.Common.Mapping.Hierarchy
{
  public class BGMappingConfig : IRegister
  {
    public void Register(TypeAdapterConfig config)
    {
      config.NewConfig<
        (SimpleCreateRequest Request, string HostId),  // src area
        CreateBGCommand>() // dest area
        .Map(dest => dest, src => src.Request);

      config.NewConfig<BG, SimpleCreateResponse>()
        .Map(dest => dest.Id, src => src.Id.Value);

    }
  }
}
