using HomeKitchen.Application.Common;
using HomeKitchen.Contracts.Authentication;
using Mapster;
namespace HomeKitchen.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User)
            .Map(dest =>dest.Token, src=>src.Token);        }
    }
}
