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

public class TaskDto : IEquatable<TaskDto>
{
    public uint Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public TaskPriority Priority { get; set; } = TaskPriority.Whatever;
    public TaskStatus Status { get; set; } = TaskStatus.Planned;
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime Deadline { get; set; }
    public bool IsDeleted { get; set; } = false;

    public bool Equals(TaskDto? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id
               && Title == other.Title
               && Description == other.Description
               && Priority == other.Priority
               && Status == other.Status
               && Created.Equals(other.Created)
               && Deadline.Equals(other.Deadline)
               && IsDeleted == other.IsDeleted;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((TaskDto)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Title, Description, (int)Priority, (int)Status, Created, Deadline, IsDeleted);
    }

    public static bool operator ==(TaskDto? left, TaskDto? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(TaskDto? left, TaskDto? right)
    {
        return !Equals(left, right);
    }
}
