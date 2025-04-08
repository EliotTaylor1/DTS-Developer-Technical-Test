using DTS_Developer_Technical_Test.Domain;
using Microsoft.EntityFrameworkCore;
using TaskStatus = System.Threading.Tasks.TaskStatus;

namespace DTS_Developer_Technical_Test.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<TaskItem> Tasks { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Name the table 'Tasks' instead of 'TaskItem'
        modelBuilder.Entity<TaskItem>().ToTable("Tasks");
        
        // use PostgreSQL enum type for Task.Status column
        modelBuilder.HasPostgresEnum<TaskStatus>(name: "task_status");
        // Map the Task.Status prop to the PostgreSQL enum
        modelBuilder.Entity<TaskItem>(entity =>
        {
            entity.Property(t => t.Status).HasColumnType("task_status");
        });
    }
}