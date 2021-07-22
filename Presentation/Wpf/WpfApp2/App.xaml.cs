using CiccioGest.Presentation.WpfApp2.View;
using CiccioGest.Presentation.WpfApp2.ViewModel;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace CiccioGest.Presentation.WpfApp2
{
    public partial class App : System.Windows.Application
    {

        private async void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            await CreateHostBuilder(e.Args).Build().RunAsync();
        }

        private IHostBuilder CreateHostBuilder(string[] args)
        {
            throw new NotImplementedException();
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

        private void OnExit(object sender, System.Windows.ExitEventArgs e)
        {

        }
    }
}
