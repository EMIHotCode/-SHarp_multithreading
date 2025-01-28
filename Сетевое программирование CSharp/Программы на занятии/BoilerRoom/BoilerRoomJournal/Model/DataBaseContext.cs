using Microsoft.EntityFrameworkCore;

namespace BoilerRoomJournal.Model;

public class DataBaseContext : DbContext
{
    private readonly string _connectionString; 
    public DbSet<Employee> Employees { get; set; } // DbSet определяет сущность для которой будет создана таблица в бд
    public DbSet<JournalPage> JournalPages { get; set; }
    
    public DataBaseContext(string connectionString)
    {
        _connectionString = connectionString; // инициализация строки подключения 
        
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_connectionString); 
    }
}