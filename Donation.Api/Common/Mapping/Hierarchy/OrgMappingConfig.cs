using Donation.Application.Hierarchy.Commands;
using Donation.Contracts.Simple;
using Donation.Domain.HierarchyAggregate;
using Mapster;
// OrgAggregate

namespace Donation.Api.Common.Mapping.Hierarchy
{
  public class OrgMappingConfig : IRegister
  {
    public void Register(TypeAdapterConfig config)
    {
      config.NewConfig<
        (SimpleCreateRequest Request, string HostId),  // src area
        CreateOrgCommand>() // dest area
        .Map(dest => dest, src => src.Request);

      config.NewConfig<Org, SimpleCreateResponse>()
        .Map(dest => dest.Id, src => src.Id.Value);

    }
  }
}
