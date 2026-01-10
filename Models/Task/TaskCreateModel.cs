namespace Droids.Models.Task;

public class TaskCreateModel
{
    public string Name { get; set; } = String.Empty;
    // [FromForm]
    public IFormFile? Image { get; set; }
}
