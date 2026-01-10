using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Droids.Entities.Identity;

namespace Droids.Entities;

[Table("tbl_task")]
public class TaskEntity : BaseEntity<long>
{
    [StringLength(250)]
    public string Name { get; set; } = String.Empty;

    [StringLength(200)]
    public string Image { get; set; } = String.Empty;

    [ForeignKey(nameof(User))]
    public long UserId { get; set; }
    public UserEntity? User { get; set; }
}
