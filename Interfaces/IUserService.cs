using Droids.Models.Account;

namespace Droids.Interfaces;

public interface IUserService
{
	Task<UserItemModel> Register(RegisterModel model);
	Task<bool> ExistsEmail(String email);
}
