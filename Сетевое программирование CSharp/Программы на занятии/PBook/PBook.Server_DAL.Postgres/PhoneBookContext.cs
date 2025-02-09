using Microsoft.EntityFrameworkCore;
using PBook.Server_DAL.Postgres.Configurations;
using PBook.Server_Model;

namespace PBook.Server_DAL.Postgres;

public class PhoneBookContext : DbContext
{
    private readonly string _connectionString;
    
    public DbSet<Person> Persons { get; set; }
    public DbSet<Phone> Phones { get; set; }

    public PhoneBookContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString, o => o
            .MapEnum<PhoneType>(nameof(PhoneType)));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PersonConfiguration());
        modelBuilder.ApplyConfiguration(new PhoneConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}