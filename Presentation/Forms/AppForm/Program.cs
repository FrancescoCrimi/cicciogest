// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

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
                host.ConfigureWinForms<SettingPresenter>();
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
                .AddTransient<SettingPresenter>()

                .AddTransient<ArticoloPresenter>()
                .AddTransient<ArticoliPresenter>()
                .AddTransient<CategoriaPresenter>()
                .AddTransient<ClientePresenter>()
                .AddTransient<ClientiPresenter>()
                .AddTransient<FatturaPresenter>()
                .AddTransient<FatturePresenter>()
                .AddTransient<FornitorePresenter>()
                .AddTransient<FornitoriPresenter>()

                .AddTransient<SelezionaArticoloPresenter>()
                .AddTransient<SelezionaCategoriaPresenter>()
                .AddTransient<SelezionaClientePresenter>()
                .AddTransient<SelezionaFatturaPresenter>()
                .AddTransient<SelezionaFornitorePresenter>()

                .AddSingleton<MainView>()
                .AddSingleton<IMainView>(sp => sp.GetService<MainView>())
                .AddTransient<ISettingView, SettingView>()

                .AddTransient<IArticoloView, ArticoloView>()
                .AddTransient<IArticoliView, ArticoliView>()
                .AddTransient<ICategoriaView, CategoriaView>()
                .AddTransient<IClienteView, ClienteView>()
                .AddTransient<IClientiView, ClientiView>()
                .AddTransient<IFatturaView, FatturaView>()
                .AddTransient<IFattureView, FattureView>()
                .AddTransient<IFornitoreView, FornitoreView>()
                .AddTransient<IFornitoriView, FornitoriView>()

                .AddTransient<ISelezionaArticoloView, SelezionaArticoloView>()
                .AddTransient<ISelezionaCategoriaView, SelezionaCategoriaView>()
                .AddTransient<ISelezionaClienteView, SelezionaClienteView>()
                .AddTransient<ISelezionaFatturaView, SelezionaFatturaView>()
                .AddTransient<ISelezionaFornitoreView, SelezionaFornitoreView>()

                .AddTransient<SettingView>();
        }
    }
}
