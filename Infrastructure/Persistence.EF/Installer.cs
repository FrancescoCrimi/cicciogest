using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Infrastructure.Persistence.EF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.EF
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IUnitOfWorkFactory, UnitOfWorkFactoryEf>().ImplementedBy<UnitOfWorkFactoryEf>().LifestyleSingleton());
            IConf conf = container.Resolve<IConf>();
            switch (conf.UserInterface)
            {
                case UI.Form:
                    container.Register(
                        Component.For<IUnitOfWork, UnitOfWorkEf>().ImplementedBy<UnitOfWorkEf>().LifestyleSingleton());
                    break;
                case UI.WPF:
                    container.Register(
                        Component.For<IUnitOfWork, UnitOfWorkEf>().ImplementedBy<UnitOfWorkEf>().LifestyleSingleton());
                    break;
                case UI.WCF:
                    container.Register(
                        Component.For<IUnitOfWork, UnitOfWorkEf>().ImplementedBy<UnitOfWorkEf>().LifestylePerWcfSession());
                    break;
                case UI.REST:
                    container.Register(
                        Component.For<IUnitOfWork, UnitOfWorkEf>().ImplementedBy<UnitOfWorkEf>().LifeStyle.PerWebRequest);
                    break;
                default:
                    break;
            }
            container.Register(
                Component.For<IFatturaRepository>().ImplementedBy<FatturaRepository>().LifeStyle.Transient,
                Component.For<IProdottoRepository>().ImplementedBy<ProdottoRepository>().LifeStyle.Transient,
                Component.For<ICategoriaRepository>().ImplementedBy<CategoriaRepository>().LifeStyle.Transient
                );
        }
    }
}
