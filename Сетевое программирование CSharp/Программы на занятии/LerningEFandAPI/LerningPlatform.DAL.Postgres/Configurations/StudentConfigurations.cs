using LerningPlatform.DAL.Postgres.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LerningPlatform.DAL.Postgres.Configurations;

public class StudentConfigurations : IEntityTypeConfiguration<StudentEntity>
{
    public void Configure(EntityTypeBuilder<StudentEntity> builder)
    {
        builder
            .HasKey(a => a.Id);

        builder
            .HasMany(a => a.Courses)
            .WithMany(c => c.Students);
    }
}

