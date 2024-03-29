using HomeKitchen.Domain.Users;

namespace HomeKitchen.Application.Common;
public record AuthenticationResult(
    User User,
    string Token);
