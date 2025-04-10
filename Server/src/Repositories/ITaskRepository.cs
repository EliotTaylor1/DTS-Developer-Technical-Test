using DTS_Developer_Technical_Test.Domain;

namespace DTS_Developer_Technical_Test.Repositories;

public interface ITaskRepository
{
    Task <TaskItem> AddAsync(TaskItem taskItem);
    Task <TaskItem?> GetByIdAsync(int id);
    Task <List<TaskItem>> GetAllAsync();
    Task <TaskItem?> UpdateAsync(TaskItem taskItem);
    Task <TaskItem?> DeleteAsync(int id);
}