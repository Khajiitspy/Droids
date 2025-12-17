using Microsoft.AspNetCore.Http;

namespace Droids.Models.Account;

public class RegisterModel
{
    public string Email { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public IFormFile? Avatar { get; set; }
}
