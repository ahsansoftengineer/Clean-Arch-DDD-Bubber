using Donation.Application.Hierarchy.Commands;
using Donation.Contracts.Simple;
using Donation.Domain.HierarchyAggregate;
using Mapster;
namespace Donation.Api.Common.Mapping.Hierarchy
{
  public class BGMappingConfig : IRegister
  {
    public void Register(TypeAdapterConfig config)
    {
      config.NewConfig<SimpleCreateRequest, CreateBGCommand>()
        .Map(dest => dest, src => src);

      config.NewConfig<SimpleAggregateParent, SimpleCreateResponse>()
        .Map(dest => dest.Id, src => src.Id.Value);

    }
  }
}
