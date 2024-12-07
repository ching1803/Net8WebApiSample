using Autofac;
using System.Reflection;

namespace Service
{
    public class ServiceAutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var dataAccess = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(dataAccess)
                   .AsImplementedInterfaces()
                   .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                   .InstancePerDependency();
        }
    }
}
