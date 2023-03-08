using Donation.Application.Hierarchy.Commands;
using Donation.Contracts.Simple;
using Donation.Domain.HierarchyAggregate;
using Mapster;
namespace Donation.Api.Common.Mapping.Hierarchy
{
  public class LEMappingConfig : IRegister
  {
    public void Register(TypeAdapterConfig config)
    {
      config.NewConfig<(SimpleRequestChildCreate Request, Guid ParentId), CreateLECommand>()
        .Map(dest => dest.ParentId, src => src.ParentId)
        .Map(dest => dest, src => src.Request);

      config.NewConfig<LE, SimpleResponseChildCreate>()
        .Map(dest => dest.Id, src => src.Id.Value)
        .Map(dest => dest.ParentId, src => src.BGId.Value);
        //.Map(dest => dest.Parent, src => src.Org.Select(org => org.Value))
        //.Map(dest => dest.ParentId, src => src.Org); // How this is going to done

    }
  }
}
