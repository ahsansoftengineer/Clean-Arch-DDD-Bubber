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
      config.NewConfig<
        (SimpleChildCreateRequest Request, string HostId),  // src area
        CreateSystemzCommand>() // dest area
        .Map(dest => dest, src => src.Request)
        .Map(dest => dest, src => src.Request);

      config.NewConfig<Systemz, SimpleChildCreateResponse>()
        .Map(dest => dest.Id, src => src.Id.Value)
        .Map(dest => dest.ParentId, src => src.OrgId.Value);
        //.Map(dest => dest.Parent, src => src.Org.Select(org => org.Value))
        //.Map(dest => dest.ParentId, src => src.Org); // How this is going to done

    }
  }
}
