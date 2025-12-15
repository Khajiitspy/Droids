using Droids.Interfaces;
using Droids.Models.Task;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Droids.Controllers;

[ApiController]
[Route("api/tasks")]
public class TaskController (ITaskService taskService) : ControllerBase
{

    [HttpGet()]
    public async Task<IActionResult> Get()
    {
        var items = await taskService.GetAllAsync();

        return Ok(items);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromForm] TaskCreateModel model)
    {
        if (model.Image == null || model.Image.Length == 0)
            return BadRequest("Image is required");

        if (string.IsNullOrWhiteSpace(model.Name))
            return BadRequest("Name is required");

        var res = await taskService.CreateTaskAsync(model);
        return Ok(res);
    }
}
