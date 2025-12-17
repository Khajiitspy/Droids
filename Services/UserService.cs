using AutoMapper;
using Droids.Data;
using Droids.Entities;
using Droids.Interfaces;
using Droids.Models.Account;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace Droids.Services;

public class UserService(AppDbContext context, IMapper mapper, IImageService imageService) : IUserService
{
	public async Task<UserItemModel> Register(RegisterModel model)
	{
        var user = new UserEntity
        {
            Email = model.Email,
            UserName = model.UserName,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password)
        };

        if (model.Avatar != null)
            user.Avatar = await imageService.SaveImageAsync(model.Avatar);

        context.Users.Add(user);
        await context.SaveChangesAsync();

		var userModel = mapper.Map<UserItemModel>(user);
		return userModel;
	}

	public async Task<bool> ExistsEmail(String email) {
    	if (context.Users.Any(x => x.Email == email))
			return true;
		return false;
	}
}
