namespace Droids.Models.Task;

public class TaskCreateModel
{
    public string Name { get; set; } = String.Empty;
    public IFormFile? Image { get; set; }
}
