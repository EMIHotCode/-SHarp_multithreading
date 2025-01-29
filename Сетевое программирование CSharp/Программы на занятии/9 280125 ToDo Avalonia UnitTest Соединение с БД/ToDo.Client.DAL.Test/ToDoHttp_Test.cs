using ToDo.Model;
using TaskStatus = ToDo.Model.TaskStatus;

namespace ToDo.Client.DAL.Test;

public class ToDoHttpTest
{
    private readonly ToDoHttp _toDoHttp = new();

    [Fact]
    public async Task GetAllTasksAsync_Test()
    {
        var expected = new List<TaskDto>()
        {
            new()
            {
                Id = 1,
                Title = "Task1",
                Description = "Description for task1",
                Priority = TaskPriority.Whatever,
                Status = TaskStatus.Planned,
                Created = new DateTime(2025, 1, 25, 19, 13, 58,074),
                Deadline = new DateTime(2025, 1, 26, 19, 14, 06,889),
                IsDeleted = false
            },
            new()
            {
                Id = 2,
                Title = "Task2",
                Description = "",
                Priority = TaskPriority.Important,
                Status = TaskStatus.InProgress,
                Created = new DateTime(2025, 1, 25, 19, 13, 58,074),
                Deadline = new DateTime(2025, 1, 26, 19, 14, 06,889),
                IsDeleted = true
            }
        };

        var actual = await _toDoHttp.GetAllTasksAsync();

        Assert.Equal(expected, actual);
    }
}
