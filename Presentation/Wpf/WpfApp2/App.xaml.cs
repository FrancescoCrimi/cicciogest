﻿using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.Client;
using CiccioGest.Presentation.WpfApp2.Contracts;
using CiccioGest.Presentation.WpfApp2.Hosting;
using CiccioGest.Presentation.WpfApp2.Service;
using CiccioGest.Presentation.WpfApp2.View;
using CiccioGest.Presentation.WpfApp2.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog.Extensions.Logging;
using System.Windows.Threading;

namespace CiccioGest.Presentation.WpfApp2
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
                .ConfigureClient()
                .AddSingleton<INavigationService, NavigationService>()
                .AddTransient<ShellView>()
                .AddTransient<ShellViewModel>()
                .AddTransient<HomeViewModel>()
                .AddTransient<HomeView>()
                .AddTransient<ListaFattureViewModel>()
                .AddTransient<ListaFattureView>()
                .AddTransient<ListaArticoliViewModel>()
                .AddTransient<ListaArticoliView>()
                .AddTransient<ListaClientiViewModel>()
                .AddTransient<ListaClientiView>()
                .AddTransient<CategoriaViewModel>()
                .AddTransient<CategoriaView>()
                .AddTransient<FatturaViewModel>()
                .AddTransient<FatturaView>()
                .AddTransient<ArticoloViewModel>()
                .AddTransient<ArticoloView>();
        }
    }
}
