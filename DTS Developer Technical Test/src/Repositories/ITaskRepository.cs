using DTS_Developer_Technical_Test.Domain;

namespace DTS_Developer_Technical_Test.Repositories;

public interface ITaskRepository
{
    TaskItem Add(TaskItem taskItem);
    TaskItem? GetById(int id);
    List<TaskItem> GetAll();
    TaskItem? Update(TaskItem taskItem);
    TaskItem? Delete(int id);
}