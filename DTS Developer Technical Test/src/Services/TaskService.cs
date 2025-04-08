using DTS_Developer_Technical_Test.Persistence;

namespace DTS_Developer_Technical_Test.Services;

public class TaskService(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public Task Create(Task task)
    {
        _context.Tasks.Add(task);
        _context.SaveChanges();
        return task;
    }

    public Task? GetById(int id)
    {
        var task = _context.Tasks.Find(id);
        return task;
    }
}