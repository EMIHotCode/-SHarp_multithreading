using Microsoft.EntityFrameworkCore;
using ToDo.Model;
using TaskStatus = ToDo.Model.TaskStatus;

namespace ToDo.DAL;

public class ToDoContext : DbContext
{
    private readonly string _connectionString;

    public DbSet<TaskDto> Tasks { get; set; }

    public ToDoContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString, o => o
            .MapEnum<TaskPriority>(nameof(TaskPriority))
            .MapEnum<TaskStatus>(nameof(TaskStatus)));
    }
}
