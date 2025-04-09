using DTS_Developer_Technical_Test.Domain;
using DTS_Developer_Technical_Test.Repositories;

namespace DTS_Developer_Technical_Test.Services;

public class TaskService(ITaskRepository repository)
{
    private readonly ITaskRepository _repository = repository;

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
        
        return _repository.Add(taskItem);
    }

    public TaskItem? GetById(int id)
    {
        return _repository.GetById(id);
    }

    public List<TaskItem> Get()
    {
        return _repository.GetAll();
    }
    
    public TaskItem? Update(int id, TaskItemDto dto)
    {
        var existingTask = _repository.GetById(id);
        if (existingTask == null)
        {
            return null;
        }
        
        existingTask.Title = dto.Title;
        existingTask.Description = dto.Description;
        existingTask.DueDate = dto.DueDate.ToUniversalTime();
        existingTask.Status = dto.Status;
        
        return _repository.Update(existingTask);
    }

    public TaskItem? Delete(int id)
    {
        return _repository.Delete(id);
    }
}