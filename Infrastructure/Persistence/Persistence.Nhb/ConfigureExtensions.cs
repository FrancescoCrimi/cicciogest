using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
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

                .AddSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>()
                .AddScoped<IUnitOfWork, UnitOfWork>()

                .AddTransient<IFatturaRepository, FatturaRepository>()
                .AddTransient<IArticoloRepository, ArticoloRepository>()
                .AddTransient<IClienteRepository, ClienteRepository>()
                .AddTransient<IFornitoreRepository, FornitoreRepository>()
                .AddTransient<ICategoriaRepository, CategoriaRepository>();
            return serviceCollection;
        }
    }
}
