using Autofac;
using Web.Controller;

namespace Web
{
    public class WebAutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .Where(t => t.Name.EndsWith("Controller")).PropertiesAutowired();
        }
    }
}
