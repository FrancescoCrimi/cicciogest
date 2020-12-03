using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.Services.Logging.NLogIntegration;
using Castle.Windsor;

namespace CiccioGest.Presentation.Wpf.App2
{
    public partial class App : System.Windows.Application
    {
        private static IWindsorContainer windsor;

        public static IWindsorContainer Windsor => windsor ?? (CreateContainer());

        private static IWindsorContainer CreateContainer()
        {
            windsor = new WindsorContainer();
            windsor.AddFacility<LoggingFacility>(f => f.LogUsing<NLogFactory>().WithConfig("NLog.config"));
            windsor.Register(Component.For<IWindowManagerService>().ImplementedBy<WindowManagerService>().LifestyleSingleton());
            return windsor;
        }
    }
}
