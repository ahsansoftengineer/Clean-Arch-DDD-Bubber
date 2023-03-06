using Donation.Application.Hierarchy.Commands;
using Donation.Contracts.Simple;
using Donation.Domain.HierarchyAggregate;
using Mapster;
// SystemzAggregate

namespace Donation.Api.Common.Mapping.Hierarchy
{
  public class SystemzMappingConfig : IRegister
  {
    public void Register(TypeAdapterConfig config)
    {
      config.NewConfig<(SimpleChildCreateRequest Request, Guid ParentId), CreateSystemzCommand>()
        .Map(dest => dest.ParentId, src => src.ParentId)
        .Map(dest => dest, src => src.Request);

      config.NewConfig<Systemz, SimpleChildCreateResponse>()
        .Map(dest => dest.Id, src => src.Id.Value)
        .Map(dest => dest.ParentId, src => src.OrgId.Value);

    }
  }
}
