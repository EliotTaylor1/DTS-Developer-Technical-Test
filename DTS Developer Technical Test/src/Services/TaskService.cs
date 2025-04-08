using DTS_Developer_Technical_Test.Persistence;

namespace DTS_Developer_Technical_Test.Services;

public class TaskService
{
    private readonly AppDbContext _context;
    TaskService(AppDbContext context)
    {
        _context = context;
    }
}