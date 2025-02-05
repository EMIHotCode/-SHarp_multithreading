using BoilerRoom.BL;
using BoilerRoom.Model;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();

var service = new JournalService(); // создаем запросы ссылаясь на слой ToDo.BL

app.MapGet("/journal", async () => await service.GetAllJournalPagesAsync());
app.MapGet("/employee", async () => await service.GetAllEmployeesAsync());
app.MapPut("/journal", async (JournalPage page) => await service.AddJournalPageAsync(page));
app.MapDelete("/journal/{date:DateTime}", async (DateTime date) => await service.DeletePagesAfterDateAsync(date));

app.Run();