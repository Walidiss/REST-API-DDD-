using HomeKitchen.Application.Common;
using HomeKitchen.Contracts.Authentication;
using HomeKitchen.Domain.Users.ValueObjects;
using Mapster;
namespace HomeKitchen.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Token, src => src.Token)
                .Map(dest => dest, src => src.User)
                .Map(dest => dest.Id, src => UserId.Create(src.User.Id.Value));
        }
    }
}
