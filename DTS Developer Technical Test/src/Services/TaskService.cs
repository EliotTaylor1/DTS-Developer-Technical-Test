using DTS_Developer_Technical_Test.Domain;
using DTS_Developer_Technical_Test.Repositories;

namespace DTS_Developer_Technical_Test.Services;

public class TaskService(ITaskService service)
{
    private readonly ITaskService _service = service;

    public TaskItem Create(TaskItemDto taskDto)
    {
        return _service.Add(taskDto);
    }

    public TaskItem? GetById(int id)
    {
        return _service.GetById(id);
    }

    public List<TaskItem> Get()
    {
        return _service.GetAll();
    }
    
    public TaskItem? Update(int id, TaskItemDto dto)
    {
        return _service.Update(id, dto);
    }

    public TaskItem? Delete(int id)
    {
        return _service.Delete(id);
    }
}