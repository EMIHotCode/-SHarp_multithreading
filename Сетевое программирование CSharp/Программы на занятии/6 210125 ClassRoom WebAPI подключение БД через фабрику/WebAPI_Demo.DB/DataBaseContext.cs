using Microsoft.EntityFrameworkCore;

namespace WebAPI_Demo.DB;

public class DataBaseContext : DbContext
{
    private readonly string _connectionString;
    
    public DbSet<Person> Persons { get; set; }
    public DbSet<Phone> Phones { get; set; }

    public DataBaseContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString,
            o => o.MapEnum<PhoneType>(nameof(PhoneType)));  // 
    }
}