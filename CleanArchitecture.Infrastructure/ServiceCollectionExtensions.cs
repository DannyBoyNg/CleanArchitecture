using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Persistence.Services;
using CleanArchitecture.SharedKernel.Services.ApiKey;
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

        //Add services
        services.AddScoped<UserService>();
        services.AddScoped<ApiKeyService>();
        services.AddScoped<IApiKeyValidator, ApiKeyValidationService>();

        return services;
    }
}
