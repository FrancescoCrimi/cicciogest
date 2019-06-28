using Castle.Facilities.TypedFactory;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Infrastructure.Persistence.Nhb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CiccioGest.Infrastructure.Persistence.Nhb
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IUnitOfWorkFactory, UnitOfWorkFactoryNhb>().ImplementedBy<UnitOfWorkFactoryNhb>().LifeStyle.Singleton);
            IConf conf = container.Resolve<IConf>();
            switch (conf.UserInterface)
            {
                case UI.Form:
                    container.Register(
                        Component.For<IUnitOfWork, UnitOfWorkNhb>().ImplementedBy<UnitOfWorkNhb>().LifestyleBoundTo<ICazzo>());
                    break;
                case UI.WPF:
                    container.Register(
                        Component.For<IUnitOfWork, UnitOfWorkNhb>().ImplementedBy<UnitOfWorkNhb>().LifestyleBoundTo<ICazzo>());
                    break;
                case UI.WCF:
                    container.Register(
                        Component.For<IUnitOfWork, UnitOfWorkNhb>().ImplementedBy<UnitOfWorkNhb>().LifestylePerWcfSession());
                    break;
                case UI.SCRIPT:
                    container.Register(
                        Component.For<IUnitOfWork, UnitOfWorkNhb>().ImplementedBy<UnitOfWorkNhb>().LifestyleSingleton());
                    break;
            }
            container.Register(
                //Component.For<ISessionFactory>().UsingFactoryMethod(k => k.Resolve<DataAccess>().SessionFactory()),
                Component.For<IFatturaRepository>().ImplementedBy<FatturaRepository>().LifeStyle.Transient,
                Component.For<IProdottoRepository>().ImplementedBy<ProdottoRepository>().LifeStyle.Transient,
                Component.For<ICategoriaRepository>().ImplementedBy<CategoriaRepository>().LifeStyle.Transient
                );
        }
    }
}
