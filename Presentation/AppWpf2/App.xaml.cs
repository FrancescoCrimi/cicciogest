using Castle.Facilities.Logging;
using Castle.Services.Logging.NLogIntegration;
using Castle.Windsor;

namespace CiccioGest.Presentation.AppWpf2
{
    public partial class App : System.Windows.Application
    {
        private static IWindsorContainer windsor;

        public static IWindsorContainer Windsor => windsor ?? (CreateContainer());

        private static IWindsorContainer CreateContainer()
        {
            windsor = new WindsorContainer();
            windsor.AddFacility<LoggingFacility>(f => f.LogUsing<NLogFactory>().WithConfig("NLog.config"));
            return windsor;
        }
    }
}
