//using Castle.Facilities.Logging;
//using Castle.Services.Logging.NLogIntegration;
//using Castle.Windsor;
using CiccioGest.Presentation.WpfApp2.View;
using CiccioGest.Presentation.WpfApp2.ViewModel;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace CiccioGest.Presentation.WpfApp2
{
    public partial class App : System.Windows.Application
    {

        private void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            Init();
        }

        private void OnExit(object sender, System.Windows.ExitEventArgs e)
        {

        }

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {

        }

        private void Init()
        {
            ViewModelLocator locator = Resources["Locator"] as ViewModelLocator;
            IWindsorContainer windsor = new WindsorContainer();
            windsor.AddFacility<LoggingFacility>(f => f.LogUsing<NLogFactory>().WithConfig("NLog.config"));
            locator.Startup(windsor);
            windsor.Resolve<ShellView>().Show();
        } 
    }
}
