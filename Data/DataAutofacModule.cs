using Autofac;
using System.Reflection;


namespace Data
{
    public class DataAutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var dataAccess = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(dataAccess)
                   .AsImplementedInterfaces()
                   .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                   .InstancePerDependency();

            //builder.RegisterType<SampleDbContext>().AsSelf();
        }
    }
}
