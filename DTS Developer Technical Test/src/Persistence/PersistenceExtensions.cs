using DTS_Developer_Technical_Test.Domain;
using Microsoft.EntityFrameworkCore;

namespace DTS_Developer_Technical_Test.Persistence;

public static class PersistenceServiceExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(opt =>
            opt.UseNpgsql(connectionString, o =>
                o.MapEnum<Status>("task_status")
            ));

        return services;
    }
}