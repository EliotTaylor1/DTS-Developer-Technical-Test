using DTS_Developer_Technical_Test.Domain;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace DTS_Developer_Technical_Test.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<TaskItem> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Set table name to Tasks instead of TaskItem
        modelBuilder.Entity<TaskItem>(entity => entity.ToTable("Tasks"));
    }
}