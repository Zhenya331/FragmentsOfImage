using Autofac;
using Autofac.Integration.WebApi;
using Server.Services.IService;
using Server.Services.ServiceImplementation;
using System.Reflection;
using System.Web.Http;

namespace WebApiServer.App_Start
{
    public class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<FragmentsImplementation>().As<IFragments>();

            var container = builder.Build();

            var resolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configuration.DependencyResolver = resolver;

        }
    }
}