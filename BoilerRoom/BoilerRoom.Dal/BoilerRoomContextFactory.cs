using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BoilerRoom.Dal;

public class BoilerRoomContextFactory : IDesignTimeDbContextFactory<BoilerRoomContext>
{
    public BoilerRoomContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
#if DEBUG
        var connectionString = config.GetConnectionString("TestConnection:ConnectionString");
        var Database = config.GetConnectionString("TestConnection:DatabaseName");
#elif RELEASE
        var connectionString = config.GetConnectionString("ProductionConnection");
#endif

        return new BoilerRoomContext(connectionString, Database);
    }

    private string[] args = [];

    public BoilerRoomContext CreateDbContext()
    {
        return CreateDbContext(args);
    }
}