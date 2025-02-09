using LerningPlatform.DAL.Postgres.Configurations;
using LerningPlatform.DAL.Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace LerningPlatform.DAL.Postgres;

public class LerningDBContext(DbContextOptions<LerningDBContext> options) : DbContext(options)
{
    public DbSet<CourseEntity> Couses { get; set; }
    public DbSet<LessonEntity> Lessons { get; set; }
    public DbSet<AuthorEntity> Authors { get; set; }
    public DbSet<StudentEntity> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CourseConfigurations());
        modelBuilder.ApplyConfiguration(new StudentConfigurations());
        modelBuilder.ApplyConfiguration(new AuthorConfigurations());
        modelBuilder.ApplyConfiguration(new LessonConfigurations());
        
        base.OnModelCreating(modelBuilder);
    }
}