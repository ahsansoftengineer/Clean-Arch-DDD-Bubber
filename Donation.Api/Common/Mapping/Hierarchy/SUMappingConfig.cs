using Donation.Application.Hierarchy.Commands;
using Donation.Contracts.Simple;
using Donation.Domain.HierarchyAggregate;
using Mapster;
// SUAggregate

namespace Donation.Api.Common.Mapping.Hierarchy
{
  public class SUMappingConfig : IRegister
  {
    public void Register(TypeAdapterConfig config)
    {
      config.NewConfig<
        (SimpleChildCreateRequest Request, string HostId),  // src area
        CreateSUCommand>() // dest area
        .Map(dest => dest.ParentId, src => src.Request.ParentId)
        .Map(dest => dest, src => src.Request);

      config.NewConfig<SU, SimpleChildCreateResponse>()
        .Map(dest => dest.Id, src => src.Id.Value)
        .Map(dest => dest.ParentId, src => src.OUId.Value);
        //.Map(dest => dest.Parent, src => src.Org.Select(org => org.Value))
        //.Map(dest => dest.ParentId, src => src.Org); // How this is going to done

    }
  }
}
