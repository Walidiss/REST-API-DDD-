using HomeKitchen.Domain.Entities;

namespace HomeKitchen.Application.Common;
public record AuthenticationResult(
    User User,
    string Token);
