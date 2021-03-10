//using Castle.MicroKernel.Registration;
//using Castle.MicroKernel.SubSystems.Configuration;
//using Castle.Windsor;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Infrastructure.Persistence.Nhb.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CiccioGest.Infrastructure.Persistence.Nhb
{
    //public class MyInstaller : IWindsorInstaller
    //{
    //    public void Install(IWindsorContainer container, IConfigurationStore store)
    //    {
    //        CiccioGestConf conf = container.Resolve<CiccioGestConf>();

    //        container.Register(
    //            Component.For<IUnitOfWorkFactory, UnitOfWorkFactory>().ImplementedBy<UnitOfWorkFactory>().LifeStyle.Singleton);     
    //        container.Register(
    //            //Component.For<ISessionFactory>().UsingFactoryMethod(k => k.Resolve<DataAccess>().SessionFactory()),
    //            Component.For<IUnitOfWork, UnitOfWork>().ImplementedBy<UnitOfWork>().LifestyleScoped(),
    //            Component.For<IFatturaRepository>().ImplementedBy<FatturaRepository>().LifeStyle.Transient,
    //            Component.For<IArticoloRepository>().ImplementedBy<ArticoloRepository>().LifeStyle.Transient,
    //            Component.For<IClienteRepository>().ImplementedBy<ClienteRepository>().LifeStyle.Transient,
    //            Component.For<IFornitoreRepository>().ImplementedBy<FornitoreRepository>().LifeStyle.Transient,
    //            Component.For<ICategoriaRepository>().ImplementedBy<CategoriaRepository>().LifeStyle.Transient);
    //    }
    //}

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
