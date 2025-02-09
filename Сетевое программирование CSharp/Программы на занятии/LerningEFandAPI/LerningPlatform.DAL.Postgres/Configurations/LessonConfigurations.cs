using LerningPlatform.DAL.Postgres.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LerningPlatform.DAL.Postgres.Configurations;

public class LessonConfigurations : IEntityTypeConfiguration<LessonEntity>
{
    public void Configure(EntityTypeBuilder<LessonEntity> builder)
    {
        builder
            .HasKey(a => a.Id);

        builder
            .HasOne(a => a.Course)
            .WithMany(c => c.Lessons)
            .HasForeignKey(l=>l.CourseId);
    }
}