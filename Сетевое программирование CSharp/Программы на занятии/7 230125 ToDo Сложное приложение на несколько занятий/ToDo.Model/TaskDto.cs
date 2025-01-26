namespace ToDo.Model;

public enum TaskPriority
{
    Important,
    Whatever
}

public enum TaskStatus
{
    Planned,
    InProgress,
    Completed,
    Paused,
    OutOfTime
}

public class TaskDto
{
    public uint Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public TaskPriority Priority { get; set; } = TaskPriority.Whatever;
    public TaskStatus Status { get; set; } = TaskStatus.Planned;
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime Deadline { get; set; }
    public bool IsDeleted { get; set; } = false;
}
