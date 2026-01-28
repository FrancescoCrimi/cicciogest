// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.Mvvm.Services;
using CiccioGest.Presentation.Mvvm.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace CiccioGest.Presentation.Mvvm
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureMvvm(this IServiceCollection serviceCollection,
                                                       CiccioGestConf conf)
        {
            serviceCollection
                .ConfigureApplication(conf)
                .AddSingleton<INavigationService, NavigationService>()
                .AddTransient<ArticoloViewModel>()
                .AddTransient<ArticoliViewModel>()
                .AddTransient<CategoriaViewModel>()
                .AddTransient<ClienteViewModel>()
                .AddTransient<ClientiViewModel>()
                .AddTransient<DashboardViewModel>()
                .AddTransient<FatturaViewModel>()
                .AddTransient<FattureViewModel>()
                .AddTransient<FornitoreViewModel>()
                .AddTransient<FornitoriViewModel>()
                .AddTransient<MainViewModel>()
                .AddTransient<SettingsViewModel>();
            return serviceCollection;
        }
    }
}
