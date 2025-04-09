namespace DTS_Developer_Technical_Test.Domain;

public class TaskItemDto
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public Status Status { get; set; }
    public DateTime DueDate { get; set; }
}