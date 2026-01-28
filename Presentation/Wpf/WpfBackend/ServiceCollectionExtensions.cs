// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.Mvvm;
using CiccioGest.Presentation.Mvvm.Services;
using CiccioGest.Presentation.WpfBackend.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CiccioGest.Presentation.WpfBackend
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureWpfBackend(this IServiceCollection serviceCollection,
                                                             CiccioGestConf conf)
        {
            serviceCollection
                .ConfigureMvvm(conf)
                //.AddSingleton<NavigationService>()
                //.AddSingleton<INavigationService>(s => s.GetRequiredService<NavigationService>())
                .AddSingleton<IMessageBoxService, MessageBoxService>();
            return serviceCollection;
        }
    }
}
