using Autofac;
using Autofac.Extensions.DependencyInjection;
using Serilog;

namespace CleanArchitecture.WebApi;

public static class HostBuilderExtensions
{
    public static IHostBuilder AddHostBuilderExtensions(this IHostBuilder builder)
    {
        //Serilog
        builder.UseSerilog((context, services, config) => config
            .ReadFrom.Configuration(context.Configuration) //appsettings.json
            .ReadFrom.Services(services)
            .Enrich.FromLogContext()
        );

        //AutoFac
        builder.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        builder.ConfigureContainer<ContainerBuilder>(containerBuilder =>
        {
            containerBuilder.RegisterModule(new DefaultCoreModule());
        });

        return builder;
    }
}
