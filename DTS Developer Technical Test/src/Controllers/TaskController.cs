using DTS_Developer_Technical_Test.Domain;
using DTS_Developer_Technical_Test.Services;
using Microsoft.AspNetCore.Mvc;

namespace DTS_Developer_Technical_Test.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController(TaskService taskService) : ControllerBase
{
    private readonly TaskService _taskService = taskService;
    
    [HttpPost]
    public IActionResult Create(TaskItem task)
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

    [HttpGet]
    public IActionResult GetTasks()
    {
        var tasks = _taskService.Get();
        return Ok(tasks);
    }
    
    [HttpPut("{id}")]
    public IActionResult Update(int id, TaskItem updatedTask)
    {
        var existingTask = _taskService.Update(id, updatedTask);
        if (existingTask == null)
        {
            return NotFound();
        }
        return Ok(existingTask);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deletedTask = _taskService.Delete(id);
        if (deletedTask == null)
        {
            return NotFound();
        }
        return Ok(deletedTask);
    }
}