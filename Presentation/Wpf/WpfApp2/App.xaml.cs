using CiccioGest.Application.Impl;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.WpfApp.Contracts;
using CiccioGest.Presentation.WpfApp.Hosting;
using CiccioGest.Presentation.WpfApp.Service;
using CiccioGest.Presentation.WpfApp.View;
using CiccioGest.Presentation.WpfApp.ViewModel;
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
                .ConfigureWPF<ShellView>()
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
                .ConfigureApplication()
                .AddSingleton<INavigationService, NavigationService>()
                .AddTransient<ShellView>()
                .AddTransient<ShellViewModel>()
                .AddTransient<HomeViewModel>()
                .AddTransient<HomeView>()

                .AddTransient<FatturaViewModel>()
                .AddTransient<FatturaView>()
                .AddTransient<FattureViewModel>()
                .AddTransient<FattureView>()
                .AddTransient<FattureDialogViewModel>()
                .AddTransient<FattureDialogView>()

                .AddTransient<ArticoliViewModel>()
                .AddTransient<ArticoliView>()
                .AddTransient<ArticoliDialogViewModel>()
                .AddTransient<ArticoliDialogView>()
                .AddTransient<ArticoloViewModel>()
                .AddTransient<ArticoloView>()

                .AddTransient<ClienteViewModel>()
                .AddTransient<ClienteView>()
                .AddTransient<ClientiViewModel>()
                .AddTransient<ClientiView>()
                .AddTransient<ClientiDialogViewModel>()
                .AddTransient<ClientiDialogView>()

                .AddTransient<CategoriaViewModel>()
                .AddTransient<CategoriaView>();
        }
    }
}
