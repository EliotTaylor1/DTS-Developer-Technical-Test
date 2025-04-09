using DTS_Developer_Technical_Test.Domain;
using DTS_Developer_Technical_Test.Persistence;

namespace DTS_Developer_Technical_Test.Repositories;

public class TaskRepository(AppDbContext context) : ITaskRepository
{
    private readonly AppDbContext _context = context;
    
    public TaskItem Add(TaskItem taskItem)
    {
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

    public TaskItem? Update(TaskItem taskItem)
    {
        _context.Tasks.Update(taskItem);
        _context.SaveChanges();
        return taskItem;
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