using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PBook.Server_Model;

namespace PBook.Server_DAL.Postgres.Configurations;

public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
{
    public void Configure(EntityTypeBuilder<Phone> builder)
    {
        builder
            .HasKey(a => a.Id);

        builder
            .HasOne(a => a.Person)
            .WithMany(p => p.Phones)
            .HasForeignKey(p =>p.PersonId);

    }
}