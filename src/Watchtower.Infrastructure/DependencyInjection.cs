using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Watchtower.Infrastructure.Persistence;

namespace Watchtower.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<WatchtowerDbContext>(options =>
            options.UseNpgsql(connectionString));

        return services;
    }
}