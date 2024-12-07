using Autofac;
using Web.Controller;

namespace Web
{
    public class WebAutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SampleController>().PropertiesAutowired();
        }
    }
}
