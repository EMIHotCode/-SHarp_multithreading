namespace ToDo.Model;

public enum TaskPriority
{
    Important, // важная
    Whatever   // неважная
}

public enum TaskStatus
{
    Planned,  //запланировано
    InProgress, // в работе
    Completed,
    Paused,
    OutOfTime
}

public class TaskDto  // Data Transfer Object (DTO) — объект передачи данных
{
    public uint Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public TaskPriority Priority { get; set; } = TaskPriority.Whatever;  // берется из enum
    public TaskStatus Status { get; set; } = TaskStatus.Planned;
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime Deadline { get; set; }
    public bool IsDeleted { get; set; } = false;
}
