using PBook.Server_BL;
using PBook.Server_Model;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();

var service = new PhoneBookService(); // создаем запросы ссылаясь на слой ToDo.BL

app.MapGet("/persons", async () => await service.GetAllPersonsAsync());
app.MapGet("/phones", async () => await service.GetAllPhonesAsync());
app.MapGet("/book", async () => await service.GetAllPersonsWithPhonesAsync());

app.MapPost("/persons", async (Person person) => await service.CreatePersonAsync(person));
app.MapPut("/persons", async (Person person) => await service.UpdatePersonAsync(person));
app.MapDelete("/persons/{id:int}", async (int id) => await service.DeletePersonAsync(id));

app.Run();