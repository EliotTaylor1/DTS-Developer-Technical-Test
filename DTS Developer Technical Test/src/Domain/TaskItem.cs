namespace DTS_Developer_Technical_Test.Domain;

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public Status Status { get; set; }
    public DateTime DueDate { get; set; }
}

public enum Status
{
    Pending,
    InProgress,
    Completed,
}