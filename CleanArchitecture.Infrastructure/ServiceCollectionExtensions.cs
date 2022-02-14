using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        //Get database connectionString
        var connectionString = configuration.GetConnectionString("Database_production");

        //Add and configure database context
        services.AddDbContext<CleanArchitectureContext>(options => options.UseSqlServer(connectionString));

        return services;
    }
}
