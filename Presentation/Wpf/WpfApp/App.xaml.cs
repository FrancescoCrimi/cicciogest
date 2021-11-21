using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.WpfApp.Hosting;
using CiccioGest.Presentation.WpfApp.Services;
using CiccioGest.Presentation.WpfApp.View;
using CiccioGest.Presentation.WpfBackend;
using CiccioGest.Presentation.WpfBackend.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog.Extensions.Logging;
using System.Windows.Threading;

namespace CiccioGest.Presentation.WpfApp
{
    public partial class App : System.Windows.Application
    {

        private async void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            await CreateHostBuilder(e.Args).Build().RunAsync();
        }


        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
        }

        private void OnExit(object sender, System.Windows.ExitEventArgs e)
        {
        } 

        private IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWPF<MainView>()
                .ConfigureLogging((hostBuilderContext, loggingBuilder) =>
                    loggingBuilder.AddNLog(hostBuilderContext.Configuration))
                .ConfigureServices(ConfigureServices);
        }

        private void ConfigureServices(HostBuilderContext hostBuilderContext,
                                       IServiceCollection serviceCollection)
        {
            CiccioGestConf conf = CiccioGestConfMgr.GetCurrent();
            serviceCollection
                .AddSingleton(conf)
                .ConfigureWpfBackend()
                .AddSingleton<NavigationService>()
                .AddSingleton<INavigationService>(s => s.GetService<NavigationService>())
                .AddSingleton<PageService>()
                .AddSingleton<IMessageBoxService, MessageBoxService>()
                .AddTransient<MainView>()
                .AddTransient<HomeView>()
                .AddTransient<ArticoliView>()
                .AddTransient<ArticoloView>()
                .AddTransient<CategoriaView>()
                .AddTransient<ClienteView>()
                .AddTransient<ClientiView>()
                .AddTransient<FatturaView>()
                .AddTransient<FattureView>()
                .AddTransient<FornitoreView>()
                .AddTransient<FornitoriView>()
                .AddTransient<ListaArticoliView>()
                .AddTransient<ListaClientiView>()
                .AddTransient<ListaFattureView>()
                .AddTransient<ListaFornitoriView>();
        }
    }
}
