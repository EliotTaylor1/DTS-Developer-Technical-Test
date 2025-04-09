using DTS_Developer_Technical_Test.Domain;
using DTS_Developer_Technical_Test.Repositories;

namespace DTS_Developer_Technical_Test.Services;

public class TaskService(ITaskRepository repository)
{
    private readonly ITaskRepository _repository = repository;

    public async Task <TaskItem> Create(TaskItemDto taskDto)
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
        
        return await _repository.AddAsync(taskItem);
    }

    public async Task <TaskItem?> GetById(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task <List<TaskItem>> Get()
    {
        return await _repository.GetAllAsync();
    }
    
    public async Task <TaskItem?> Update(int id, TaskItemDto dto)
    {
        var existingTask = await _repository.GetByIdAsync(id);
        if (existingTask == null)
        {
            return null;
        }
        
        existingTask.Title = dto.Title;
        existingTask.Description = dto.Description;
        existingTask.DueDate = dto.DueDate.ToUniversalTime();
        existingTask.Status = dto.Status;
        
        return await _repository.UpdateAsync(existingTask);
    }

    public async Task <TaskItem?> Delete(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}