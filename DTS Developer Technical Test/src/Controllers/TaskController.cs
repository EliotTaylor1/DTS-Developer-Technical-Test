using DTS_Developer_Technical_Test.Services;
using Microsoft.AspNetCore.Mvc;

namespace DTS_Developer_Technical_Test.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController(TaskService taskService) : ControllerBase
{
    private readonly TaskService _taskService = taskService;
    
    [HttpPost]
    public IActionResult Create(Task task)
    {
        var createdTask = _taskService.Create(task);
        return CreatedAtAction(
            nameof(GetTask),
            new { id = createdTask.Id },
            createdTask
            );
    }
    
    [HttpGet("{id}")]
    public IActionResult GetTask(int id)
    {
        var task = _taskService.GetById(id);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }
}