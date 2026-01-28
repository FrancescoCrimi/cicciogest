// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.FormsApp.Presenters;
using CiccioGest.Presentation.FormsApp.Services;
using CiccioGest.Presentation.FormsApp.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace CiccioGest.Presentation.FormsApp
{
    public static class ConfigureServiceProviderExtensions
    {
        public static HostApplicationBuilder ConfigureFormsApp(this HostApplicationBuilder builder)
        {
            var gestConf = CiccioGestConfMgr.GetCurrent();

            builder.Services

                .AddSingleton(gestConf)
                .ConfigureApplication(gestConf)

                .AddTransient<WindowService>()

                .AddTransient<MainPresenter>()
                .AddTransient<SettingPresenter>()

                .AddTransient<ArticoloPresenter>()
                .AddTransient<ArticoliPresenter>()
                .AddTransient<CategoriaPresenter>()
                .AddTransient<CategoriePresenter>()
                .AddTransient<ClientePresenter>()
                .AddTransient<ClientiPresenter>()
                .AddTransient<FatturaPresenter>()
                .AddTransient<FatturePresenter>()
                .AddTransient<FornitorePresenter>()
                .AddTransient<FornitoriPresenter>()

                .AddSingleton<MainView>()
                .AddSingleton<IMainView>(sp => sp.GetRequiredService<MainView>())
                .AddTransient<ISettingView, SettingView>()

                .AddTransient<IArticoloView, ArticoloView>()
                .AddTransient<IArticoliView, ArticoliView>()
                .AddTransient<ICategoriaView, CategoriaView>()
                .AddTransient<ICategorieView, CategorieView>()
                .AddTransient<IClienteView, ClienteView>()
                .AddTransient<IClientiView, ClientiView>()
                .AddTransient<IFatturaView, FatturaView>()
                .AddTransient<IFattureView, FattureView>()
                .AddTransient<IFornitoreView, FornitoreView>()
                .AddTransient<IFornitoriView, FornitoriView>()

                .AddTransient<SettingView>();

            return builder;
        }
    }
}
