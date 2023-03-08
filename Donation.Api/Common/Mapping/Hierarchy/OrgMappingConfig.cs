using Donation.Application.Hierarchy.Commands;
using Donation.Contracts.Simple;
using Donation.Domain.HierarchyAggregate;
using Mapster;
namespace Donation.Api.Common.Mapping.Hierarchy
{
  public class OrgMappingConfig : IRegister
  {
    public void Register(TypeAdapterConfig config)
    {
      config.NewConfig<SimpleCreateRequest, CreateOrgCommand>()
        .Map(dest => dest, src => src);

      config.NewConfig<Org, SimpleCreateResponse>()
        .Map(dest => dest.Id, src => src.Id.Value);

    }
  }
}
