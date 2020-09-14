using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure.Persistence.LiteDB.Repository;
using System;

namespace CiccioGest.Infrastructure.Persistence.LiteDB
{
    public class MyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                //Component.For<ISessionFactory>().UsingFactoryMethod(k => k.Resolve<DataAccess>().SessionFactory()),
                Component.For<IUnitOfWorkFactory, UnitOfWorkFactory>().ImplementedBy<UnitOfWorkFactory>().LifeStyle.Singleton,
                Component.For<IUnitOfWork, UnitOfWork>().ImplementedBy<UnitOfWork>().LifeStyle.Singleton,
                Component.For<IFatturaRepository>().ImplementedBy<FatturaRepository>().LifeStyle.Singleton,
                Component.For<IArticoloRepository>().ImplementedBy<ArticoloRepository>().LifeStyle.Singleton,
                Component.For<IClienteRepository>().ImplementedBy<ClienteRepository>().LifeStyle.Singleton,
                Component.For<IFornitoreRepository>().ImplementedBy<FornitoreRepository>().LifeStyle.Singleton,
                Component.For<ICategoriaRepository>().ImplementedBy<CategoriaRepository>().LifeStyle.Singleton);
        }
    }
}
