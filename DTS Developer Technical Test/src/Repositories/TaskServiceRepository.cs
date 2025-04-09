using DTS_Developer_Technical_Test.Domain;
using DTS_Developer_Technical_Test.Persistence;

namespace DTS_Developer_Technical_Test.Repositories;

public class TaskServiceRepository(AppDbContext context) : ITaskService
{
    private readonly AppDbContext _context = context;
    
    public TaskItem Add(TaskItemDto dto)
    {
        // Convert timestamp to UTC in case it's not already for whatever reason
        dto.DueDate = dto.DueDate.ToUniversalTime();
        
        var taskItem = new TaskItem
        {
            Title = dto.Title,
            Description = dto.Description,
            Status = dto.Status,
            DueDate = dto.DueDate
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

    public List<TaskItem> GetAll()
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

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}