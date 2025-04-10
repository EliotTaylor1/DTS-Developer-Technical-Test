using DTS_Developer_Technical_Test.Domain;
using DTS_Developer_Technical_Test.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DTS_Developer_Technical_Test.Repositories;

public class TaskRepository(AppDbContext context) : ITaskRepository
{
    private readonly AppDbContext _context = context;
    
    public async Task<TaskItem> AddAsync(TaskItem taskItem)
    {
        await _context.Tasks.AddAsync(taskItem);
        await _context.SaveChangesAsync();
        return taskItem;
    }

    public async Task <TaskItem?> GetByIdAsync(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        return task;
    }

    public async Task <List<TaskItem>> GetAllAsync()
    {
        return await _context.Tasks.ToListAsync();
    }

    public async Task <TaskItem?> UpdateAsync(TaskItem taskItem)
    {
        await _context.SaveChangesAsync();
        return taskItem;
    }

    public async Task <TaskItem?> DeleteAsync(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null)
        {
            return null;
        }

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return task;
    }
}