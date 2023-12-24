// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application.Impl;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.AppForm.Presenter;
using CiccioGest.Presentation.AppForm.Services;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm
{
    public static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();
            if (args.Contains("config"))
            {
                var win = ConfigureServices().GetRequiredService<SettingPresenter>();
                System.Windows.Forms.Application.Run((Form)win.View);
            }
            else
            {
                var win = ConfigureServices().GetRequiredService<MainPresenter>();
                System.Windows.Forms.Application.Run((Form)win.View);
            }
        }

        private static IServiceProvider ConfigureServices()
        {
            var gestConf = CiccioGestConfMgr.GetCurrent();

            var appLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(appLocation!)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                .Build();

            return new ServiceCollection()
                .AddLogging(loggingBuilder =>
                {
                    loggingBuilder.AddConfiguration(configuration.GetSection("Logging"));
                    loggingBuilder.AddNLog();
                    loggingBuilder.AddDebug();
                })

                .AddSingleton(gestConf)
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
                .AddSingleton<IMainView>(sp => sp.GetRequiredService<MainView>())
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

                .AddTransient<SettingView>()
                .BuildServiceProvider();
        }
    }
}
