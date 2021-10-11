using CiccioGest.Application.Impl;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.AppForm.Hosting;
using CiccioGest.Presentation.AppForm.Presenter;
using CiccioGest.Presentation.AppForm.Services;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.AppForm
{
    public static class Program
    {
        [STAThread]
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args);
            if (args.Contains("config"))
            {
                //host.ConfigureWinForms<SettingView>();
            }
            else
            {
                host.ConfigureWinForms<MainPresenter>();
            }
            host.ConfigureLogging((hostBuilderContext, loggingBuilder)
                => loggingBuilder.AddNLog(hostBuilderContext.Configuration));
            host.ConfigureServices(ConfigureServices);
            return host;
        }

        private static void ConfigureServices(HostBuilderContext hostBuilderContext,
                                              IServiceCollection serviceCollection)
        {
            var conf = CiccioGestConfMgr.GetCurrent();
            serviceCollection
                .AddSingleton(conf)
                .ConfigureApplication()
                .AddTransient<WindowService>()
                .AddTransient<DialogService>()
                .AddTransient<MainPresenter>()
                .AddTransient<ListaFatturePresenter>()
                .AddTransient<FatturaPresenter>()
                .AddTransient<ListaClientiPresenter>()
                .AddTransient<CategoriaPresenter>()
                .AddTransient<ArticoloPresenter>()
                .AddTransient<ListaFornitoriPresenter>()
                .AddTransient<ListaArticoliPresenter>()
                .AddTransient<SelectClientePresenter>()
                .AddSingleton<MainView>()
                .AddSingleton<IMainView>(sp => sp.GetService<MainView>())
                .AddTransient<IListaFattureView, ListaFattureView>()
                .AddTransient<IFatturaView, FatturaView>()
                .AddTransient<IListaClientiView, ListaClientiView>()
                .AddTransient<ICategoriaView, CategoriaView>()
                .AddTransient<IArticoloView, ArticoloView>()
                .AddTransient<IListaFornitoriView, ListaFornitoriView>()
                .AddTransient<IListaArticoliView, ListaArticoliView>()
                .AddTransient<ISelectClienteView, SelectClienteView>()
                .AddTransient<SettingView>();
        }
    }
}
