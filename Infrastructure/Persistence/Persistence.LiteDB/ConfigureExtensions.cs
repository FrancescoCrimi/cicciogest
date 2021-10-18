using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
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
