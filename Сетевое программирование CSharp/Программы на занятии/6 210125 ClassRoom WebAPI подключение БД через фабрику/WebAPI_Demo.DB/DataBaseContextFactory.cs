using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;  // Чтобы работать с json подключаем эту библиотеку

namespace WebAPI_Demo.DB;

public class DataBaseContextFactory : IDesignTimeDbContextFactory<DataBaseContext> // используется в Program.cs
{
    public DataBaseContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
#if DEBUG
        var connectionString = config.GetConnectionString("TestConnection");
#elif RELEASE
        var connectionString = config.GetConnectionString("PublicConnection");
#endif

        return new DataBaseContext(connectionString);
    }
    
    // создадим метод из этого контекста который не будет требовать аргументы, а будет тянуть по умолчанию 
    private string[] _args => Array.Empty<string>(); // создали массив аргументов, сделали его пустым (тоесть из пустых строк)
    public DataBaseContext CreateDbContext() => CreateDbContext(_args); // создали метод класса без аргументов (смотри выше с аргументами)
    // чтобы не создавать какие то новые классы а использовать класс фабрики и из него берем метод без аргументов 
    // в этом случае будет работать через экземпляр класса (класс по умолчанию работает через интерфейс)
}