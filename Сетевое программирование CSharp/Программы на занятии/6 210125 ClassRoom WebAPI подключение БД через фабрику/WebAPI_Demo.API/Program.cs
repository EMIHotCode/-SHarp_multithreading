using Microsoft.EntityFrameworkCore;
using WebAPI_Demo.DB;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();

var dbFactory = new DataBaseContextFactory(); // создаем сначала фабрику 
var db = dbFactory.CreateDbContext();  // через экземпляр фабрики без параметров

db.Phones.Include(p => p.Person).ToList();

app.MapGet("/persons", async () => await db.Persons.ToListAsync());
app.MapGet("/person/{id:guid}", async (Guid id) =>
    await db.Persons.SingleOrDefaultAsync(p => p.Id == id));
app.MapGet("/phones", async () => await db.Phones.ToListAsync());

app.Run();