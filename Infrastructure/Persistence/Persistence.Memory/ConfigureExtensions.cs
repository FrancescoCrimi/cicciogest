// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazzino;
using CiccioGest.Infrastructure.Persistence.Memory.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CiccioGest.Infrastructure.Persistence.Memory
{
    public static class ConfigureExtensions
    {
        public static IServiceCollection ConfigurePersistenceMemory(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddSingleton<IFatturaRepository, FatturaRepository>()
                .AddSingleton<IArticoloRepository, ArticoloRepository>()
                .AddSingleton<ICategoriaRepository, CategoriaRepository>()
                .AddSingleton<IUnitOfWork, UnitOfWork>();
            return serviceCollection;
        }
    }
}
