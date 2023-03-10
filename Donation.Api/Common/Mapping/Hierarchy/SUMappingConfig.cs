using Donation.Application.Hierarchy.Commands;
using Donation.Application.Simple;
using Donation.Contracts.Simple;
using Donation.Domain.HierarchyAggregate;
using Mapster;

namespace Donation.Api.Common.Mapping.Hierarchy
{
  public class SUMappingConfig : IRegister
  {
    public void Register(TypeAdapterConfig config)
    {
      config.NewConfig<(SimpleRequestChildCreate Request, Guid ParentId), SimpleCommandChildCreate<OU>>()
        .Map(dest => dest.ParentId, src => src.ParentId)
        .Map(dest => dest, src => src.Request);

      config.NewConfig<SU, SimpleResponseChildCreate>()
        .Map(dest => dest.Id, src => src.Id.Value)
        .Map(dest => dest.ParentId, src => src.OUId.Value);
    }
  }
}
