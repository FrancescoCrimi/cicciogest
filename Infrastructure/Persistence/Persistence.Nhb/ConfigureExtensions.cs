// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Anagrafica;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazzino;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Infrastructure.Persistence.Nhb.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CiccioGest.Infrastructure.Persistence.Nhb
{
    public static class ConfigureExtensions
    {
        public static IServiceCollection ConfigurePersistenceNhb(this IServiceCollection serviceCollection)
        {
            serviceCollection
                //.AddSingleton<UnitOfWorkFactory>()
                //.AddSingleton<IUnitOfWorkFactory>(serviceCollection => serviceCollection.GetService<UnitOfWorkFactory>())
                //.AddScoped<UnitOfWork>()
                //.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetService<UnitOfWork>())

                .AddSingleton<UnitOfWorkFactory>()
                .AddSingleton<IUnitOfWorkFactory>((sp) => sp.GetService<UnitOfWorkFactory>()!)
                .AddSingleton<UnitOfWork>()
                .AddSingleton<IUnitOfWork>((sp) => sp.GetService<UnitOfWork>()!)

                .AddTransient<IFatturaRepository, FatturaRepository>()
                .AddTransient<IArticoloRepository, ArticoloRepository>()
                .AddTransient<IClienteRepository, ClienteRepository>()
                .AddTransient<IFornitoreRepository, FornitoreRepository>()
                .AddTransient<ICategoriaRepository, CategoriaRepository>();
            return serviceCollection;
        }
    }
}
