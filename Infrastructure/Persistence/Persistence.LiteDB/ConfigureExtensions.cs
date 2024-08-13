// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazzino;
using CiccioGest.Infrastructure.Persistence.LiteDB.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CiccioGest.Infrastructure.Persistence.LiteDB
{
    public static class ConfigureExtensions
    {
        public static IServiceCollection ConfigurePersistenceLiteDB(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>()
                .AddSingleton<IUnitOfWork, UnitOfWork>()
                .AddSingleton<IFatturaRepository, FatturaRepository>()
                .AddSingleton<IArticoloRepository, ArticoloRepository>()
                .AddSingleton<IClienteRepository, ClienteRepository>()
                .AddSingleton<IFornitoreRepository, FornitoreRepository>()
                .AddSingleton<ICategoriaRepository, CategoriaRepository>();
            return serviceCollection;
        }
    }
}
