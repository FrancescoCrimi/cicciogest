// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application.Impl;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Infrastructure.Persistence.Nhb;
using Microsoft.Extensions.DependencyInjection;

namespace CiccioGest.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection serviceCollection,
                                                              CiccioGestConf conf)
        {
            return serviceCollection
                .ConfigurePersistenceNhb(conf)
                .AddTransient<IFatturaService, FatturaService>()
                .AddTransient<IMagazzinoService, MagazzinoService>()
                .AddTransient<IAnagraficaService, AnagraficaService>()
                .AddTransient<ISettingService, SettingService>();
        }
    }
}
