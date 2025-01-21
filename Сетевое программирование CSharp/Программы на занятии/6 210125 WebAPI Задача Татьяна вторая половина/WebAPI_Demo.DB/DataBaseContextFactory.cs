using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace WebAPI_Demo.DB;

public class DataBaseContextFactory : IDesignTimeDbContextFactory<DataBaseContext>
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
    
    private string[] _args => Array.Empty<string>();
    public DataBaseContext CreateDbContext() => CreateDbContext(_args);
}