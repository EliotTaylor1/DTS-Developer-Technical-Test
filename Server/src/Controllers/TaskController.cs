using DTS_Developer_Technical_Test.Domain;
using DTS_Developer_Technical_Test.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DTS_Developer_Technical_Test.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController(TaskService taskService) : ControllerBase
{
    private readonly TaskService _taskService = taskService;
    
    [EnableCors("localhost")]
    [HttpPost]
    public async Task<IActionResult> Create(TaskItemDto task)
    {
        var createdTask = await _taskService.Create(task);
        return CreatedAtAction(
            nameof(GetTask),
            new { id = createdTask.Id },
            createdTask
            );
    }
    
    [EnableCors("localhost")]
    [HttpGet("{id}")]
    public async Task <IActionResult> GetTask(int id)
    {
        var task = await _taskService.GetById(id);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }

    [EnableCors("localhost")]
    [HttpGet]
    public async Task<IActionResult> GetTasks()
    {
        var tasks = await _taskService.Get();
        return Ok(tasks);
    }
    
    [EnableCors("localhost")]
    [HttpPut("{id}")]
    public async Task <IActionResult> Update(int id, TaskItemDto updatedTask)
    {
        var existingTask = await _taskService.Update(id, updatedTask);
        if (existingTask == null)
        {
            return NotFound();
        }
        return Ok(existingTask);
    }

    [EnableCors("localhost")]
    [HttpDelete("{id}")]
    public async Task <IActionResult> Delete(int id)
    {
        var deletedTask = await _taskService.Delete(id);
        if (deletedTask == null)
        {
            return NotFound();
        }
        return Ok(deletedTask);
    }
}