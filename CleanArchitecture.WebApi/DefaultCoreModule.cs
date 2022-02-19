using Autofac;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.SharedKernel.Interfaces;
using Module = Autofac.Module;

namespace CleanArchitecture.WebApi;

public class DefaultCoreModule : Module
{
    public DefaultCoreModule()
    {

    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(EfRepository<>))
        .As(typeof(IRepository<>))
        .As(typeof(IReadRepository<>))
        .InstancePerLifetimeScope();
    }
}
