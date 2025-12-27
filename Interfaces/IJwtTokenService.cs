using Droids.Entities.Identity;

namespace Droids.Interfaces;

public interface IJWTTokenService
{
    Task<string> CreateTokenAsync(UserEntity user);
}
