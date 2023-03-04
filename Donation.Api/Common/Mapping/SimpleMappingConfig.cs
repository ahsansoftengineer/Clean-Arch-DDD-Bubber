using Mapster;
// MenuAggregate
using Donation.Domain.Hierarchy;
using Donation.Contracts.Common;
using Donation.Application.Common.Commands;

namespace Donation.Api.Common.Mapping
{
    public class SimpleMappingConfig : IRegister
  {
    public void Register(TypeAdapterConfig config)
    {
      //// no need of it
      config.NewConfig<
        CreateSimpleRequest,
        CreateSimpleCommand<Org>>();

      //config.NewConfig<
      //  CreateSimpleRequest,
      //  CreateSimpleCommand<BG>>();

      config.NewConfig<
        CreateSimpleChildRequest,
        CreateSimpleChildCommand<Systemz>>()
          .Map(dest => dest.ParentId, src => src.ParentId);

      //config.NewConfig<
      //  CreateSimpleChildRequest,
      //  CreateSimpleChildCommand<LE>>()
      //    .Map(dest => dest.ParentId, src => src.ParentId);

      config.NewConfig<Org, SimpleResponse>()
        .Map(dest => dest.Id, src => src.Id.Value);

      config.NewConfig<Systemz, SimpleChildResponse>()
        .Map(dest => dest.Id, src => src.Id.Value);

      //config.NewConfig<BG, SimpleResponse>()
      //  .Map(dest => dest.Id, src => src.Id.Value);

      //config.NewConfig<LE, SimpleChildResponse>()
      //  .Map(dest => dest.Id, src => src.Id.Value);

      //config.NewConfig<OU, SimpleChildResponse>()
      //  .Map(dest => dest.Id, src => src.Id.Value);

      //config.NewConfig<SU, SimpleChildResponse>()
      //  .Map(dest => dest.Id, src => src.Id.Value);

    }
  }
}
