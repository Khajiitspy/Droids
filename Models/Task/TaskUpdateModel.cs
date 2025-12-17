namespace Droids.Models.Task;

public class TaskUpdateModel
{
    public long Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public IFormFile? Image { get; set; }
}
