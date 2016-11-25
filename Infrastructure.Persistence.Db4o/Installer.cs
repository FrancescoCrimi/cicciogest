using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Ciccio1.Domain;
using Ciccio1.Infrastructure.Conf;
using Castle.Facilities.TypedFactory;
using Castle.Facilities.WcfIntegration;

namespace Ciccio1.Infrastructure.Persistence.Db4o
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            IConf conf = container.Resolve<IConf>();
            switch (conf.UserInterface)
            {
                case UI.Form:
                    container.Register(
                        Component.For<DataAccess, IDataAccess>().ImplementedBy<DataAccess>().LifeStyle.Singleton);
                    break;
                case UI.WPF:
                    container.Register(
                        Component.For<DataAccess, IDataAccess>().ImplementedBy<DataAccess>().LifeStyle.Singleton);
                    break;
                case UI.WCF:
                    container.Register(
                        Component.For<DataAccess, IDataAccess>().ImplementedBy<DataAccess>().LifestylePerWcfSession());
                    break;
            }
            container.Register(
                //Component.For<IObjectContainer>().UsingFactoryMethod(k => k.Resolve<IDb4oDataAccess>().OpenSession()).LifeStyle.Transient,
                //Component.For<IUnitOfWork, ISessioneDb4o>().UsingFactoryMethod(k => k.Resolve<IDataAccess>().Sessione()).LifeStyle.Transient,
                Component.For<IFatturaRepository>().ImplementedBy<FatturaRepository>().LifeStyle.Transient,
                Component.For<IProdottoRepository>().ImplementedBy<ProdottoRepository>().LifeStyle.Transient,
                Component.For<ICategoriaRepository>().ImplementedBy<CategoriaRepository>().LifeStyle.Transient,
                Component.For<Func<IDataAccess, IFatturaRepository>>().AsFactory(),
                Component.For<Func<IDataAccess, IProdottoRepository>>().AsFactory(),
                Component.For<Func<IDataAccess, ICategoriaRepository>>().AsFactory()
                );
        }
    }
}
