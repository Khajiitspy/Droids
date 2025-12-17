using Droids.Interfaces;
using Droids.Models.Account;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Droids.Controllers;

[ApiController]
[Route("api/user")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromForm] RegisterModel model)
    {
    	if (await userService.ExistsEmail(model.Email))
			return BadRequest("Email already exists");

        Console.WriteLine($"Email: '{model.Email}'");
        Console.WriteLine($"UserName: '{model.UserName}'");
        Console.WriteLine($"Password: '{model.Password}'");
        Console.WriteLine($"Avatar: {model.Avatar != null}");

        var res = await userService.Register(model);

        return Ok(res);
    }
}
