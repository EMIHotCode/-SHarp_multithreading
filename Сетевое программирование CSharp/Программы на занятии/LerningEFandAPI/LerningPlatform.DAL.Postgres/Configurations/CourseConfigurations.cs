using LerningPlatform.DAL.Postgres.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LerningPlatform.DAL.Postgres.Configurations;

public class CourseConfigurations : IEntityTypeConfiguration<CourseEntity>
{
    public void Configure(EntityTypeBuilder<CourseEntity> builder)
    {
        builder
            .HasKey(a => a.Id);

        builder
            .HasOne(a => a.Author)
            .WithOne(c => c.Course)
            .HasForeignKey<CourseEntity>(c =>c.AuthorId);
        
        builder
            .HasMany(c => c.Lessons)
            .WithOne(l => l.Course)
            .HasForeignKey(l=>l.CourseId);
        
        builder
            .HasMany(c => c.Students)
            .WithMany(s => s.Courses);
    }
}