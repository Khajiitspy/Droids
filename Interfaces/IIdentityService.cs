namespace Droids.Interfaces;

public interface IIdentityService
{
    Task<long> GetUserIdAsync();
}
