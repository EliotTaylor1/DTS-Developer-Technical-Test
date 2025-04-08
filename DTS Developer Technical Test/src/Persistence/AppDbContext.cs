using Microsoft.EntityFrameworkCore;

namespace DTS_Developer_Technical_Test.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Task> Tasks { get; set; }
    
    // use PostgreSQL enum type for Task.Status column
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<TaskStatus>(name: "task_status");

        // Map the Task.Status prop to the PostgreSQL enum
        modelBuilder.Entity<Task>(entity =>
        {
            entity.Property(t => t.Status).HasColumnType("task_status");
        });
    }
}