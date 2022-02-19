using CleanArchitecture.Infrastructure.Email;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        //Add and configure database context
        var connectionString = configuration.GetConnectionString("Database_production");
        services.AddDbContext<CleanArchitectureContext>(options => options.UseSqlServer(connectionString));

        //Add and configure email service
        services.AddScoped<IEmailService, EmailService>();
        services.Configure<EmailSettings>(options => options.Host = "smtp.examplemailserver.com");

        return services;
    }
}
