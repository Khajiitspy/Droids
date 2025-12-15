using System.ComponentModel.DataAnnotations;

namespace Droids.Entities;

public interface IEntity<T>
{
    T Id { get; set; }
    bool IsDeleted { get; set; }
    DateTime DateCreated { get; set; }
}

public abstract class BaseEntity<T> : IEntity<T>
{
    [Key]
    [Required]
    public T Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
}
