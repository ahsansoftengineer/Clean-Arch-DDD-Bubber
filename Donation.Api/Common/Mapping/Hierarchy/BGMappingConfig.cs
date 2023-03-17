using Donation.Application.Hierarchy.Commands;
using Donation.Application.Simple;
using Donation.Contracts.Simple;
using Donation.Domain.HierarchyAggregate;
using Mapster;

namespace Donation.Api.Common.Mapping.Hierarchy
{
  public class BGMappingConfig : IRegister
  {
    public void Register(TypeAdapterConfig config)
    {
      config.NewConfig<CommandRequestCreateSimple, SimpleCommandCreate<BG>>()
        .Map(dest => dest, src => src);

      config.NewConfig<BG, ResponseSimpleCreate>()
        .Map(dest => dest.Id, src => src.Id.Value);

    }
  }
}
