using Atlas.Infrastructure.EF;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Configuration;
using System.Web.Http;

namespace Atlas.Infrastructure.Ioc
{
    internal class WebWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AtlasContext"].ConnectionString;

            container.Register( 
               
                Component.For<IDbContext>()
                         .ImplementedBy<AtlasContext>()
                         .LifestylePerWebRequest()
                         .DependsOn(Parameter.ForKey("nameOrConnectionString").Eq(connectionString)),
                                                  
                Classes.FromThisAssembly()
                        .Where(type =>
                                       //type.Name.EndsWith("Services") ||  
                                       type.Name.EndsWith("Controller"))
                        .WithService.DefaultInterfaces()
                        .LifestyleTransient()
            );

            //AutomapperConfiguration.Configure(container.Resolve);
            GlobalConfiguration.Configuration.DependencyResolver = new WindsorDependencyResolver(container);
        }
    }
}