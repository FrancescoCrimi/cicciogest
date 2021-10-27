using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.WpfBackend;
using CiccioGest.Presentation.WpfBackend.Services;
using CiccioGest.Presentation.WpfMetroApp.Hosting;
using CiccioGest.Presentation.WpfMetroApp.Services;
using CiccioGest.Presentation.WpfMetroApp.View;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;
using System.Windows.Threading;

namespace CiccioGest.Presentation.WpfMetroApp
{
    public partial class App : System.Windows.Application
    {
        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            await CreateHostBuilder(e.Args).Build().RunAsync();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {

        }

        private void Application_DispatcherUnhandledException(object sender,
                                                              DispatcherUnhandledExceptionEventArgs e)
        {

        }

        private IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWPF<MainView>()
                //.ConfigureLogging((hostBuilderContext, loggingBuilder) =>
                //    loggingBuilder.AddNLog(hostBuilderContext.Configuration))
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
                .AddTransient<ArticoliView>()
                .AddTransient<ArticoliListView>()
                .AddTransient<ArticoloView>()
                .AddTransient<CategoriaView>()
                .AddTransient<ClienteView>()
                .AddTransient<ClientiView>()
                .AddTransient<ClientiListView>()
                .AddTransient<FatturaView>()
                .AddTransient<FattureView>()
                .AddTransient<FattureListView>();
        }
    }
}
