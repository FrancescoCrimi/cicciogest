using CiccioGest.Application.Impl;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.WpfApp.View;
using CiccioGest.Presentation.WpfApp.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog.Extensions.Logging;
using System;
using System.Windows;
using System.Windows.Threading;

namespace CiccioGest.Presentation.WpfApp
{
    public partial class App : System.Windows.Application
    {
        private async void OnStartup(object sender, StartupEventArgs e)
        {
            await CreateHostBuilder(e.Args).Build().RunAsync();
        }

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
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
            serviceCollection
                .AddSingleton(CiccioGestConfMgr.GetCurrent())
                .ConfigureApplication()

                .AddTransient<MainViewModel>()
                .AddTransient<FattureViewModel>()
                .AddTransient<FattureDialogViewModel>()
                .AddTransient<ArticoliViewModel>()
                .AddTransient<ArticoliDialogViewModel>()
                .AddTransient<ClientiViewModel>()
                .AddTransient<ClientiDialogViewModel>()
                .AddTransient<CategoriaViewModel>()
                .AddTransient<FatturaViewModel>()
                .AddTransient<ArticoloViewModel>()

                .AddTransient<MainView>()
                .AddTransient<FattureView>()
                .AddTransient<FattureDialogView>()
                .AddTransient<ArticoliView>()
                .AddTransient<ArticoliDialogView>()
                .AddTransient<ClientiView>()
                .AddTransient<ClientiDialogView>()
                .AddTransient<CategoriaView>()
                .AddTransient<FatturaView>()
                .AddTransient<ArticoloView>();
        }

        private void OnExit(object sender, ExitEventArgs e)
        {

        }
    }
}
