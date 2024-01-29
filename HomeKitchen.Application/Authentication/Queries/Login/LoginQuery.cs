using ErrorOr;
using HomeKitchen.Application.Common;
using MediatR;

namespace HomeKitchen.Application.Authentication.Queries.Login
{
    public record LoginQuery(string Email, string Password) :IRequest<ErrorOr<AuthenticationResult>>;
}
