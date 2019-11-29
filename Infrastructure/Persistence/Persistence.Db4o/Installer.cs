using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Infrastructure.Persistence.Db4o.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CiccioGest.Infrastructure.Persistence.Db4o
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IUnitOfWorkFactory, UnitOfWorkFactoryDb4o>().ImplementedBy<UnitOfWorkFactoryDb4o>().LifeStyle.Singleton);
            IConf conf = container.Resolve<IConf>();
            switch (conf.UserInterface)
            {
                case UI.Form:
                    container.Register(
                        Component.For<IUnitOfWork, UnitOfWorkDb4o>().ImplementedBy<UnitOfWorkDb4o>().LifeStyle.Singleton);
                    break;
                case UI.WPF:
                    container.Register(
                        Component.For<IUnitOfWork, UnitOfWorkDb4o>().ImplementedBy<UnitOfWorkDb4o>().LifeStyle.Singleton);
                    break;

            }
            container.Register(
                //Component.For<IObjectContainer>().UsingFactoryMethod(k => k.Resolve<IDb4oDataAccess>().OpenSession()).LifeStyle.Transient,
                //Component.For<IUnitOfWork, ISessioneDb4o>().UsingFactoryMethod(k => k.Resolve<IDataAccess>().Sessione()).LifeStyle.Transient,
                Component.For<IFatturaRepository>().ImplementedBy<FatturaRepository>().LifeStyle.Transient,
                Component.For<IArticoloRepository>().ImplementedBy<ArticoloRepository>().LifeStyle.Transient,
                Component.For<ICategoriaRepository>().ImplementedBy<CategoriaRepository>().LifeStyle.Transient
                //Component.For<Func<IDataAccess, IFatturaRepository>>().AsFactory(),
                //Component.For<Func<IDataAccess, IProdottoRepository>>().AsFactory(),
                //Component.For<Func<IDataAccess, ICategoriaRepository>>().AsFactory()
                );
        }
    }
}
