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
using Ciccio1.Infrastructure.Persistence.Nhb.Repository;

namespace Ciccio1.Infrastructure.Persistence.Nhb
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
                        Component.For<DataAccess, IDataAccess>().ImplementedBy<DataAccess>().LifestyleScoped());
                    break;
                case UI.WPF:
                    container.Register(
                        Component.For<DataAccess, IDataAccess>().ImplementedBy<DataAccess>().LifestyleSingleton());
                    break;
                case UI.WCF:
                    container.Register(
                        Component.For<DataAccess, IDataAccess>().ImplementedBy<DataAccess>().LifestylePerWcfSession());
                    //Component.For<DataAccess, IDataAccess>().ImplementedBy<DataAccess>().LifestylePerWcfOperation());
                    //Component.For<DataAccess, IDataAccess>().ImplementedBy<DataAccess>().LifestylePerWebRequest());
                    break;
                case UI.REST:
                    container.Register(
                        Component.For<DataAccess, IDataAccess>().ImplementedBy<DataAccess>().LifeStyle.PerWebRequest
                        );
                    break;
            }
            container.Register(
                //Component.For<ISessionFactory>().UsingFactoryMethod(k => k.Resolve<DataAccess>().SessionFactory()),
                //Component.For<IUnitOfWorkFactory, IUnitOfWorkFactoryNhb>().ImplementedBy<UnitOfWorkFactoryNhb>().LifeStyle.Transient,
                Component.For<IFatturaRepository>().ImplementedBy<FatturaRepository>().LifeStyle.Transient,
                Component.For<IProdottoRepository>().ImplementedBy<ProdottoRepository>().LifeStyle.Transient,
                Component.For<ICategoriaRepository>().ImplementedBy<CategoriaRepository>().LifeStyle.Transient
                //Component.For<Func<IDataAccess, IFatturaRepository>>().AsFactory(),
                //Component.For<Func<IDataAccess, IProdottoRepository>>().AsFactory(),
                //Component.For<Func<IDataAccess, ICategoriaRepository>>().AsFactory()
                );
        }
    }
}
