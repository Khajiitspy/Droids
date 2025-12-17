using Microsoft.AspNetCore.Http;

namespace Droids.Models.Account;

public class UserItemModel
{
    public int Id {get; set;}
    public string Email { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string? Avatar { get; set; }
}
