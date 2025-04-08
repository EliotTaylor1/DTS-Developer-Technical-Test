using Microsoft.EntityFrameworkCore;

namespace DTS_Developer_Technical_Test.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Task> Tasks { get; set; }
}