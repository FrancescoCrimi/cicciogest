//using Castle.MicroKernel.Registration;
//using Castle.MicroKernel.SubSystems.Configuration;
//using Castle.Windsor;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure.Persistence.Memory.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CiccioGest.Infrastructure.Persistence.Memory
{
    //public class MyInstaller : IWindsorInstaller
    //{
    //    public void Install(IWindsorContainer container, IConfigurationStore store)
    //    {
    //        container.Register(
    //            //Component.For<ISessionFactory>().UsingFactoryMethod(k => k.Resolve<DataAccess>().SessionFactory()),
    //            Component.For<IFatturaRepository>().ImplementedBy<FatturaRepository>().LifeStyle.Singleton,
    //            Component.For<IArticoloRepository>().ImplementedBy<ArticoloRepository>().LifeStyle.Singleton,
    //            Component.For<ICategoriaRepository>().ImplementedBy<CategoriaRepository>().LifeStyle.Singleton,
    //            Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>().LifeStyle.Singleton);
    //    }
    //}

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
