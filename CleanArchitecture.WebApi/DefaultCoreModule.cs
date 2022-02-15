using Autofac;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.SharedKernel.Interfaces;
using Module = Autofac.Module;

namespace CleanArchitecture.WebApi;

public class DefaultCoreModule : Module
{
    //private readonly bool _isDevelopment = false;
    //private readonly List<Assembly> _assemblies = new List<Assembly>();

    public DefaultCoreModule()
    {
        //_isDevelopment = isDevelopment;
        //var coreAssembly = Assembly.GetAssembly(typeof(Project)); // TODO: Replace "Project" with any type from your Core project
        //var infrastructureAssembly = Assembly.GetAssembly(typeof(StartupSetup));
        //if (coreAssembly != null)
        //{
        //  _assemblies.Add(coreAssembly);
        //}
        //if (infrastructureAssembly != null)
        //{
        //  _assemblies.Add(infrastructureAssembly);
        //}
        //if (callingAssembly != null)
        //{
        //  _assemblies.Add(callingAssembly);
        //}
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(EfRepository<>))
        .As(typeof(IRepository<>))
        .As(typeof(IReadRepository<>))
        .InstancePerLifetimeScope();
    }
}
