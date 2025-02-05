using BoilerRoom.Model;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace BoilerRoom.Dal;

public class BoilerRoomContext : DbContext
{
    /*private readonly string _connectionString;
    private readonly string _database;*/
    
    public DbSet<Employee> Employees { get; set; }
    public DbSet<JournalPage> JournalPages { get; set; }
    
    private readonly MongoClient _client;

    public BoilerRoomContext(MongoClient client)
    {
        _client = client;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMongoDB(_client, "efsample");
    
    /*public BoilerRoomContext(string connectionString, string database)
    {
        _connectionString = connectionString;
        _database = database;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMongoDB(_connectionString, _database);
    }*/
}

/*public class CustomersContext : DbContext  пример 
{
    private readonly MongoClient _client;
    public CustomersContext(MongoClient client)
    {
        _client = client;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMongoDB(_client, "efsample");

    public DbSet<Customer> Customers => Set<Customer>();
}*/