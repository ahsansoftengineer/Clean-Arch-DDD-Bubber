using Donation.Application.Hierarchy.Commands;
using Donation.Contracts.Simple;
using Donation.Domain.HierarchyAggregate;
using Mapster;
// OUAggregate

namespace Donation.Api.Common.Mapping.Hierarchy
{
  public class OUMappingConfig : IRegister
  {
    public void Register(TypeAdapterConfig config)
    {
      config.NewConfig<
        (SimpleChildCreateRequest Request, string HostId),  // src area
        CreateOUCommand>() // dest area
        .Map(dest => dest.ParentId, src => src.Request.ParentId)
        .Map(dest => dest, src => src.Request);

      config.NewConfig<OU, SimpleChildCreateResponse>()
        .Map(dest => dest.Id, src => src.Id.Value)
        .Map(dest => dest.ParentId, src => src.LEId.Value);
        //.Map(dest => dest.Parent, src => src.Org.Select(org => org.Value))
        //.Map(dest => dest.ParentId, src => src.Org); // How this is going to done

    }
  }
}
