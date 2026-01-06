// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.Mvvm;
using CiccioGest.Presentation.Mvvm.Services;
using CiccioGest.Presentation.WinUiBackend.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CiccioGest.Presentation.WinUiBackend
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureWinUiBackend(this IServiceCollection serviceCollection,
                                                               CiccioGestConf conf)
        {
            return serviceCollection
                //.ConfigureApplication()
                .ConfigureMvvm(conf)
                .AddSingleton<IMessageBoxService, MessageBoxService>()
                //.AddTransient<MainViewModel>()
                //.AddTransient<ArticoloViewModel>()
                //.AddTransient<ArticoliViewModel>()
                //.AddTransient<CategoriaViewModel>()
                //.AddTransient<ClienteViewModel>()
                //.AddTransient<ClientiViewModel>()
                //.AddTransient<FatturaViewModel>()
                //.AddTransient<FattureViewModel>()
                //.AddTransient<FornitoreViewModel>()
                //.AddTransient<FornitoriViewModel>()
                //.AddTransient<ListaArticoliViewModel>()
                //.AddTransient<ListaClientiViewModel>()
                //.AddTransient<ListaFattureViewModel>()
                //.AddTransient<ListaFornitoriViewModel>()
                //.AddTransient<DashboardViewModel>()
                //.AddTransient<SettingsViewModel>()
                ;
        }
    }
}
