using System.Net.Http.Json;
using ToDo.Model;

namespace ToDo.Client.DAL;

public class ToDoHttp
{
    private static readonly HttpClient Client = new();
    private static readonly Uri GetAllTasksUri = new("http://localhost:5243/tasks");
    private static readonly Uri PostCreateTasksUri = new("http://localhost:5243/tasks");

    public async Task<IEnumerable<TaskDto>?> GetAllTasksAsync() =>
        await Client.GetFromJsonAsync<IEnumerable<TaskDto>>(GetAllTasksUri);

    public async Task CreateTaskAsync(TaskDto task) =>
        await Client.PostAsJsonAsync(PostCreateTasksUri, task);
}
