using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
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
