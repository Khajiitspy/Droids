using Droids.Interfaces;
using Droids.Models.Account;
using Microsoft.AspNetCore.Mvc;

namespace Droids.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        string result = await authService.LoginAsync(model);
        return Ok(new
        {
            Token = result
        });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromForm] RegisterModel model)
    {
        string result = await authService.RegisterAsync(model);
        if (string.IsNullOrEmpty(result))
        {
            return BadRequest(new
            {
                Status = 400,
                IsValid = false,
                Errors = new { Email = "Ïîìèëêà ðåºñòðàö³¿" }
            });
        }
        return Ok(new
        {
            Token = result
        });
    }
}
