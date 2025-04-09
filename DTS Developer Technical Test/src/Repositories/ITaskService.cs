using DTS_Developer_Technical_Test.Domain;

namespace DTS_Developer_Technical_Test.Repositories;

public interface ITaskService
{
    TaskItem Add(TaskItemDto dto);
    TaskItem? GetById(int id);
    List<TaskItem> GetAll();
    TaskItem? Update(int id, TaskItemDto dto);
    TaskItem? Delete(int id);
    void SaveChanges();
}