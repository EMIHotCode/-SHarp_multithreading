using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ToDo.DAL;

public class ToDoContextFactory : IDesignTimeDbContextFactory<ToDoContext>  // метод и класс который создают объект ToDoContext
{
    public ToDoContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
#if DEBUG
        var connectionString = config.GetConnectionString("TestConnection");
#elif RELEASE
        var connectionString = config.GetConnectionString("ProductionConnection");
#endif

        return new ToDoContext(connectionString);
    }

    private string[] args = [];

    public ToDoContext CreateDbContext()
    {
        return CreateDbContext(args);
    }
}
