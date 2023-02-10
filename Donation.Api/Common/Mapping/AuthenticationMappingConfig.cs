using Donation.Application.Authentication.Commands.Register;
using Donation.Application.Authentication.Common;
using Donation.Application.Authentication.Query.Login;
using Donation.Contracts.Authentication;
using Mapster;

namespace Donation.Api.Common.Mapping
{
  public class AuthenticationMappingConfig : IRegister
  {

    // Other Auth Record Map Automatically b/c their keys are same
    // RegisterRequest -> RegisterCommand
    // LoginRequest -> LoginQuery
    public void Register(TypeAdapterConfig config)
    {
      // Redundant Code (Done by Mapster Automatically)
      // But It shows the flow
      config.NewConfig<RegisterRequest, RegisterCommand>();
      config.NewConfig<LoginRequest, LoginQuery>();

      // 
      config.NewConfig<AuthenticationResult, AuthenticationResponse>()
        //.Map(dest => dest.Token, src => src.Token)
        .Map(dest => dest, src => src.User);
    }
  }
}
