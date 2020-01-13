using Castle.Facilities.Logging;
using Castle.Services.Logging.NLogIntegration;
using Castle.Windsor;
using CiccioGest.Presentation.Wpf.App1.Contracts;
using CiccioGest.Presentation.Wpf.App1.View;
using CiccioGest.Presentation.Wpf.App1.ViewModel;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace CiccioGest.Presentation.Wpf.App1
{
    public partial class App : System.Windows.Application
    {
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

        private void Init()
        {
            ViewModelLocator locator = Resources["Locator"] as ViewModelLocator;
            IWindsorContainer windsor = new WindsorContainer();
            windsor.AddFacility<LoggingFacility>(f => f.LogUsing<NLogFactory>().WithConfig("NLog.config"));
            locator.Startup(windsor);
            windsor.Resolve<ShellView>().Show();
        }

        private void Application_Startup(object sender, System.Windows.StartupEventArgs e)
        {
            Init();
        }

        private void Application_Exit(object sender, System.Windows.ExitEventArgs e)
        {

        }

        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {

        }
    }
}
