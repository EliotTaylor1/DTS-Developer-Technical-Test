using DTS_Developer_Technical_Test.Domain;
using DTS_Developer_Technical_Test.Persistence;

namespace DTS_Developer_Technical_Test.Services;

public class TaskService(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public TaskItem Create(TaskItemDto taskDto)
    {
        // Convert timestamp to UTC in case it's not already for whatever reason
        taskDto.DueDate = taskDto.DueDate.ToUniversalTime();
        
        var taskItem = new TaskItem
        {
            Title = taskDto.Title,
            Description = taskDto.Description,
            Status = taskDto.Status,
            DueDate = taskDto.DueDate
        };
        
        _context.Tasks.Add(taskItem);
        _context.SaveChanges();
        return taskItem;
    }

    public TaskItem? GetById(int id)
    {
        var task = _context.Tasks.Find(id);
        return task;
    }

    public List<TaskItem> Get()
    {
        return _context.Tasks.ToList();
    }
    
    public TaskItem? Update(int id, TaskItemDto dto)
    {
        var existingTask = _context.Tasks.Find(id);
        if (existingTask == null)
        {
            return null;
        }

        existingTask.Title = dto.Title;
        existingTask.Description = dto.Description;
        existingTask.DueDate = dto.DueDate.ToUniversalTime();
        existingTask.Status = dto.Status;
        
        _context.SaveChanges();
        return existingTask;
    }

    public TaskItem? Delete(int id)
    {
        var task = _context.Tasks.Find(id);
        if (task == null)
        {
            return null;
        }

        _context.Tasks.Remove(task);
        _context.SaveChanges();
        return task;
    }
}