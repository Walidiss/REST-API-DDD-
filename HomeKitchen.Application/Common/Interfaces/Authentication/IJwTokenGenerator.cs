
namespace HomeKitchen.Application.Common.Interfaces.Authentication
{
    public interface IJwTokenGenerator
    {
      public string GenerateToken(Guid userId, string firstName, string lastName);
    }
}
