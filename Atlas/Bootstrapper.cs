using Atlas.Infrastructure.Ioc;
using Castle.Windsor;

namespace Atlas
{ 
    public static class Bootstrapper
	{
		public static IWindsorContainer InitializeContainer()
		{
            return new WindsorContainer().Install(new WebWindsorInstaller());
		}

		public static void Release(IWindsorContainer container)
		{
			container.Dispose();
		}
	}
}
