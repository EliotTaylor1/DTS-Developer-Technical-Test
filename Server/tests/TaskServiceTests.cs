using DTS_Developer_Technical_Test.Domain;
using DTS_Developer_Technical_Test.Repositories;
using DTS_Developer_Technical_Test.Services;
using Moq;
using Xunit;

namespace DTS_Developer_Technical_Test.tests;

public class TaskServiceTests
{
    private readonly Mock<ITaskRepository> _mockRepo;
    private readonly TaskService _taskService;

    public TaskServiceTests()
    {
        _mockRepo = new Mock<ITaskRepository>();
        _taskService = new TaskService(_mockRepo.Object);
    }

    [Fact]
    public async Task Create_ValidDto_ReturnsTaskWithUtcDueDate()
    {
        // Arrange
        var localTime = DateTime.Now;
        var taskDto = new TaskItemDto 
        { 
            Title = "Test Task",
            DueDate = localTime,
            Status = Status.Pending
        };

        var expectedTask = new TaskItem 
        { 
            Title = "Test Task",
            DueDate = localTime.ToUniversalTime()
        };

        _mockRepo.Setup(r => r.AddAsync(It.IsAny<TaskItem>()))
                 .ReturnsAsync(expectedTask);

        // Act
        var result = await _taskService.Create(taskDto);

        // Assert
        _mockRepo.Verify(r => r.AddAsync(It.Is<TaskItem>(t => 
            t.DueDate.Kind == DateTimeKind.Utc &&
            t.DueDate == localTime.ToUniversalTime()
        )), Times.Once);
        
        Assert.Equal(expectedTask, result);
    }

    [Fact]
    public async Task GetById_ExistingId_ReturnsTask()
    {
        // Arrange
        var taskId = 1;
        var expectedTask = new TaskItem { Id = taskId };
        _mockRepo.Setup(r => r.GetByIdAsync(taskId))
                 .ReturnsAsync(expectedTask);

        // Act
        var result = await _taskService.GetById(taskId);

        // Assert
        Assert.Equal(expectedTask, result);
    }

    [Fact]
    public async Task GetById_InvalidId_ReturnsNull()
    {
        // Arrange
        _mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                 .ReturnsAsync((TaskItem?)null);

        // Act
        var result = await _taskService.GetById(999);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task GetAll_ReturnsTaskList()
    {
        // Arrange
        var tasks = new List<TaskItem>
        {
            new TaskItem { Id = 1 },
            new TaskItem { Id = 2 }
        };
        
        _mockRepo.Setup(r => r.GetAllAsync())
                 .ReturnsAsync(tasks);

        // Act
        var result = await _taskService.Get();

        // Assert
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task Update_ExistingTask_UpdatesPropertiesAndSaves()
    {
        // Arrange
        var taskId = 1;
        
        var originalTask = new TaskItem 
        { 
            Id = taskId,
            Title = "Original Title",
            Status = Status.Pending,
            DueDate = DateTime.UtcNow
        };

        var updateDto = new TaskItemDto
        {
            Title = "Updated Title",
            DueDate = DateTime.UtcNow.AddDays(1),
            Status = Status.InProgress
        };

        _mockRepo.Setup(r => r.GetByIdAsync(taskId))
                 .ReturnsAsync(originalTask);

        // Act
        var result = await _taskService.Update(taskId, updateDto);

        // Assert
        Assert.Equal("Updated Title", result!.Title);
        Assert.Equal(Status.InProgress, result.Status);
        Assert.Equal(updateDto.DueDate, result.DueDate);
        _mockRepo.Verify(r => r.UpdateAsync(originalTask), Times.Once);
    }

    [Fact]
    public async Task Update_NonExistingTask_ReturnsNull()
    {
        // Arrange
        _mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                 .ReturnsAsync((TaskItem?)null);

        // Act
        var result = await _taskService.Update(999, new TaskItemDto());

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task Delete_ExistingTask_ReturnsDeletedTask()
    {
        // Arrange
        var taskId = 1;
        var expectedTask = new TaskItem { Id = taskId };
        _mockRepo.Setup(r => r.DeleteAsync(taskId))
                 .ReturnsAsync(expectedTask);

        // Act
        var result = await _taskService.Delete(taskId);

        // Assert
        Assert.Equal(expectedTask, result);
    }

    [Fact]
    public async Task Delete_NonExistingTask_ReturnsNull()
    {
        // Arrange
        _mockRepo.Setup(r => r.DeleteAsync(It.IsAny<int>()))
                 .ReturnsAsync((TaskItem?)null);

        // Act
        var result = await _taskService.Delete(999);

        // Assert
        Assert.Null(result);
    }
}