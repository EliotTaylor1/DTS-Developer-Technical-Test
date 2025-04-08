using DTS_Developer_Technical_Test.Domain;
using DTS_Developer_Technical_Test.Persistence;

namespace DTS_Developer_Technical_Test.Services;

public class TaskService(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public TaskItem Create(TaskItem task)
    {
        // Convert timestamp to UTC in case it's not already for whatever reason
        task.DueDate = task.DueDate.ToUniversalTime();
        
        _context.Tasks.Add(task);
        _context.SaveChanges();
        return task;
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
    
    public TaskItem? Update(int id, TaskItem updatedTask)
    {
        var existingTask = _context.Tasks.Find(id);
        if (existingTask == null)
        {
            return null;
        }

        // Update all properties except Id
        _context.Entry(existingTask).CurrentValues
            .SetValues(updatedTask);
        existingTask.Id = id;
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