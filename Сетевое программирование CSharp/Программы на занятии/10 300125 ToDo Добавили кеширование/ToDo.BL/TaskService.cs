using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using ToDo.DAL;
using ToDo.Model;

namespace ToDo.BL;

public class TaskService
{
    private readonly ToDoContext _context;
    private readonly IDistributedCache _cache;

    public TaskService()
    {
        var contextFactory = new ToDoContextFactory();
        _context = contextFactory.CreateDbContext();

        _cache = new RedisCache(new RedisCacheOptions {Configuration = "localhost"});
    }

    public async Task<IEnumerable<TaskDto>?> GetAllTasksAsync()
    {
        var temp = await _cache.GetStringAsync("tasks");
        if (temp is not null) return JsonSerializer.Deserialize<List<TaskDto>>(temp);

        var tasks = await _context.Tasks.ToListAsync();
        await _cache.SetStringAsync("tasks", JsonSerializer.Serialize(tasks));
        return tasks;
    }

    public async Task<TaskDto?> GetTaskByIdAsync(int id)
    {
        return await _context.Tasks.SingleOrDefaultAsync(t => t.Id == id);
    }

    public async Task UpdateTaskAsync(TaskDto task)
    {
        var temp = await _context.Tasks.SingleOrDefaultAsync(t => t.Id == task.Id);
        if (temp == null) throw new NullReferenceException();
        //_context.Entry(temp).CurrentValues.SetValues(task);
        temp.Title = task.Title;
        temp.Description = task.Description;
        temp.Created = task.Created;
        temp.Deadline = task.Deadline;
        temp.Priority = task.Priority;
        temp.Status = task.Status;
        temp.IsDeleted = task.IsDeleted;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteTaskAsync(int id)
    {
        var temp = await _context.Tasks.SingleOrDefaultAsync(t => t.Id == id);
        if (temp == null) throw new NullReferenceException();

        temp.IsDeleted = true;
        await _context.SaveChangesAsync();
    }

    public async Task CreateTaskAsync(TaskDto task)
    {
        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
    }
}
