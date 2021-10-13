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
                .AddTransient<ArticoloPresenter>()
                .AddTransient<CategoriaPresenter>()
                .AddTransient<ClientePresenter>()
                .AddTransient<FatturaPresenter>()
                .AddTransient<FornitorePresenter>()

                .AddTransient<ArticoliPresenter>()
                .AddTransient<ClientiPresenter>()
                .AddTransient<FatturePresenter>()
                .AddTransient<FornitoriPresenter>()

                .AddTransient<SelezionaArticoloPresenter>()
                .AddTransient<SelezionaClientePresenter>()

                .AddSingleton<MainView>()
                .AddSingleton<IMainView>(sp => sp.GetService<MainView>())

                .AddTransient<IArticoloView, ArticoloView>()
                .AddTransient<ICategoriaView, CategoriaView>()
                .AddTransient<IClienteView, ClienteView>()
                .AddTransient<IFatturaView, FatturaView>()
                .AddTransient<IFornitoreView, FornitoreView>()
                .AddTransient<IArticoliView, ArticoliView>()
                .AddTransient<IClientiView, ClientiView>()
                .AddTransient<IFattureView, FattureView>()
                .AddTransient<IFornitoriView, FornitoriView>()
                .AddTransient<ISelezionaArticoloView, SelezionaArticoloView>()
                .AddTransient<ISelezionaClienteView, SelezionaClienteView>()

                .AddTransient<SettingView>();
        }
    }
}
