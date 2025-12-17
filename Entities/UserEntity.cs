using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Droids.Entities;

[Table("tbl_users")]
public class UserEntity : BaseEntity<long>
{
    [StringLength(250)]
    public string Email { get; set; } = null!;

    [StringLength(250)]
    public string UserName { get; set; } = null!;

    [StringLength(250)]
    public string PasswordHash { get; set; } = null!;

    [StringLength(250)]
    public string? Avatar { get; set; }
}
