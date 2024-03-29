
using HomeKitchen.Domain.Users;

namespace HomeKitchen.Application.Common.Interfaces.Authentication
{
    public interface IJwTokenGenerator
    {
      public string GenerateToken(User user);
    }
}
