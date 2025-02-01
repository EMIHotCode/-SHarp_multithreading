using ToDo.BL;
using ToDo.Model;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();

var service = new TaskService();

app.MapGet("/tasks", async () => await service.GetAllTasksAsync());//FIXME
app.MapGet("/tasks/{id:int}", async (int id) => await service.GetTaskByIdAsync(id));//FIXME
app.MapPost("/tasks", async (TaskDto task) => await service.CreateTaskAsync(task));
app.MapPut("/tasks", async (TaskDto task) => await service.UpdateTaskAsync(task));
app.MapDelete("/tasks/{id:int}", async (int id) => await service.DeleteTaskAsync(id));

app.Run();
