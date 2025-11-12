// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application.Impl;
using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
//using CiccioGest.Infrastructure.Persistence.LiteDB;
//using CiccioGest.Infrastructure.Persistence.Memory;
using CiccioGest.Infrastructure.Persistence.Nhb;
using Microsoft.Extensions.DependencyInjection;

namespace CiccioGest.Application
{
    public static class ConfigureExtensions
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection serviceCollection)
        {
            var conf = serviceCollection.BuildServiceProvider().GetService<CiccioGestConf>();
            switch (conf?.DataAccess)
            {
                case Storage.NHibernate:
                    serviceCollection.ConfigurePersistenceNhb();
                    break;
                //case Storage.EF:
                //    break;
                //case Storage.LiteDb:
                //    serviceCollection.ConfigurePersistenceLiteDB();
                //    break;
                //case Storage.Memory:
                //    serviceCollection.ConfigurePersistenceMemory();
                //    break;
                default:
                    break;
            }
            serviceCollection
                .AddTransient<IFatturaService, FatturaService>()
                .AddTransient<IMagazzinoService, MagazzinoService>()
                .AddTransient<IAnagraficaService, AnagraficaService>()
                .AddTransient<ISettingService, SettingService>();
            return serviceCollection;
        }
    }
}
