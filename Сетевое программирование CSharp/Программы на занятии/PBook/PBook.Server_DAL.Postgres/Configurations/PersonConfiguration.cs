using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PBook.Server_Model;

namespace PBook.Server_DAL.Postgres.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder
            .HasKey(p => p.Id);
        
        builder
            .HasMany(pe => pe.Phones)
            .WithOne(ph => ph.Person);
    }
}