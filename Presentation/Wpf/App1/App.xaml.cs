using Castle.Facilities.Logging;
using Castle.Services.Logging.NLogIntegration;
using Castle.Windsor;
using System.Windows.Threading;

namespace CiccioGest.Presentation.Wpf.App1
{
    public partial class App : System.Windows.Application
    {
        private static IWindsorContainer windsor;

        public static bool InDesignMode
        {
            get
            {
                if (App.Current.MainWindow != null)
                    return System.ComponentModel.DesignerProperties.GetIsInDesignMode(App.Current.MainWindow);
                //return System.ComponentModel.DesignerProperties.IsInDesignModeProperty;
                //return (System.Windows.Application.Current is App);
                return true;
            }
        }

        public static IWindsorContainer Windsor => windsor ?? (CreateContainer());

        private static IWindsorContainer CreateContainer()
        {
            windsor = new WindsorContainer();
            windsor.AddFacility<LoggingFacility>(f => f.LogUsing<NLogFactory>().WithConfig("NLog.config"));
            return windsor;
        }

        private void Application_Startup(object sender, System.Windows.StartupEventArgs e)
        {

        }

        private void Application_Exit(object sender, System.Windows.ExitEventArgs e)
        {

        }

        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {

        }
    }
}
