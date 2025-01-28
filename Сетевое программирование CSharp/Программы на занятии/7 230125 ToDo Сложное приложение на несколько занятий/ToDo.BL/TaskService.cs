using Microsoft.EntityFrameworkCore;
using ToDo.DAL;
using ToDo.Model;

namespace ToDo.BL;

public class TaskService  //В нем реализуем методы получить все GetAll, добавить Add, GetByID, Update, Delete
{
    private readonly ToDoContext _context;

    public TaskService()
    {
        var contextFactory = new ToDoContextFactory();
        _context = contextFactory.CreateDbContext();
    }

    public async Task<IEnumerable<TaskDto>> GetAllTasksAsync()
    {
        return await _context.Tasks.ToListAsync();
    }

    public async Task<TaskDto?> GetTaskByIdAsync(int id) // TaskDto? может вернуть null если неправильно укажем id
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
