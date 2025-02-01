using ToDo.Client.DAL;
using ToDo.Model;

namespace ToDo.Client.BL;

public class Service
{
    private readonly ToDoHttp _http = new ToDoHttp();

    public async Task<IEnumerable<TaskDto>?> GetAllTasksAsync() =>
        await _http.GetAllTasksAsync();

    public async Task AddTaskAsync(TaskDto task) =>
        await _http.CreateTaskAsync(task);

    public async Task UpdateTaskAsync(TaskDto task) =>
        await _http.UpdateTaskAsync(task);
}
