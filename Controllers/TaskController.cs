using Droids.Interfaces;
using Droids.Models.Zadachi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Droids.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TaskController(ITaskService taskService) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        Thread.Sleep(2000);
        var items = await taskService.GetAllAsync();

        return Ok(items);
    }

    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Post([FromForm] TaskCreateModel model)
    {
        var res = await taskService.CreateTaskAsync(model);
        return Ok(res);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var res = await taskService.DeleteTaskAsync(id);
        if (!res)
        {
            return NotFound();
        }
        return Ok();
    }

    [HttpDelete("range")]
    public async Task<IActionResult> DeleteRange([FromBody] List<long> ids)
    {
        var res = await taskService.DeleteRangeTaskAsync(ids);
        if (!res)
        {
            return NotFound();
        }
        return Ok();
    }

    [HttpPut]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Put([FromForm] TaskUpdateModel model)
    {
        var res = await taskService.UpdateTaskAsync(model);
        if (!res)
        {
            return NotFound();
        }
        return Ok();
    }
}
