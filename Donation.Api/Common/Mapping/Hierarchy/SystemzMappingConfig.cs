using Donation.Application.Simple;
using Donation.Contracts.Simple;
using Donation.Domain.HierarchyAggregate;
using Donation.Domain.SimpleAggregates;
using Mapster;

namespace Donation.Api.Common.Mapping.Hierarchy
{
  public class SystemzMappingConfig : IRegister
  {
    public void Register(TypeAdapterConfig config)
    {
      config.NewConfig<CommandRequestCreateSimpleChild, SimpleCommandChildCreate<Systemz>>()
        .Map(dest => dest, src => src);

      config.NewConfig<Systemz, SimpleResponseChildCreate>()
        .Map(dest => dest.Id, src => src.Id.Value)
        .Map(dest => dest.ParentId, src => src.OrgId.Value);

      config.NewConfig<Guid, SimpleQueryGetById<Systemz>>()
      .Map(dest => dest.Id, src => SimpleValueObject.Create(src));

      config.NewConfig<Guid, SimpleQueryGetByIdwithParent<Systemz>>()
        .Map(dest => dest.Id, src => SimpleValueObject.Create(src));

      config.NewConfig<Systemz, SimpleResponseChildwithParent>()
        .Map(dest => dest.Id, src => src.Id.Value)
        .Map(dest => dest.ParentId, src => src.OrgId.Value)
        .Map(dest => dest.Parent, src => new SimpleOption(src.Org.Id.Value.ToString(), src.Org.Title));

    }
  }
}
