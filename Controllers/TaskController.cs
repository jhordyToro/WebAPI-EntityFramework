using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    ITaskService TaskService;

    public TaskController(ITaskService task)
    {
        TaskService = task;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(TaskService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] minimalAPIef.Models.Task Task)
    {
        TaskService.Save(Task);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] minimalAPIef.Models.Task Task)
    {
        TaskService.Update(id, Task);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        TaskService.Delete(id);
        return Ok();
    }
}