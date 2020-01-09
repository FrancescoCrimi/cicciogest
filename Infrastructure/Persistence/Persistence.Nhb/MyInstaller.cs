//using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Infrastructure.Persistence.Nhb.Repository;

namespace CiccioGest.Infrastructure.Persistence.Nhb
{
    public class MyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            ISetLifeStyle slf = container.Resolve<ISetLifeStyle>();
            IAppConf conf = container.Resolve<IAppConf>();

            container.Register(
                Component.For<IUnitOfWorkFactory, UnitOfWorkFactory>().ImplementedBy<UnitOfWorkFactory>().LifeStyle.Singleton);

            //switch (conf.UserInterface)
            //{
            //    case UI.Form:
            //        container.Register(
            //            Component.For<IUnitOfWork, UnitOfWorkNhb>().ImplementedBy<UnitOfWorkNhb>().LifestyleBoundTo<ICazzo>());
            //        break;
            //    case UI.WPF:
            //        container.Register(
            //            Component.For<IUnitOfWork, UnitOfWorkNhb>().ImplementedBy<UnitOfWorkNhb>().LifestyleBoundTo<ICazzo>());
            //        break;
            //    case UI.WCF:
            //        container.Register(
            //            Component.For<IUnitOfWork, UnitOfWorkNhb>().ImplementedBy<UnitOfWorkNhb>().LifestylePerWcfSession());
            //        //Component.For<IUnitOfWork, UnitOfWorkNhb>().ImplementedBy<UnitOfWorkNhb>().Ci);
            //        break;
            //    case UI.SCRIPT:
            //        container.Register(
            //            Component.For<IUnitOfWork, UnitOfWorkNhb>().ImplementedBy<UnitOfWorkNhb>().LifestyleSingleton());
            //        break;
            //}
            container.Register(
                //Component.For<ISessionFactory>().UsingFactoryMethod(k => k.Resolve<DataAccess>().SessionFactory()),
                Component.For<IFatturaRepository>().ImplementedBy<FatturaRepository>().LifeStyle.Transient,
                Component.For<IArticoloRepository>().ImplementedBy<ArticoloRepository>().LifeStyle.Transient,
                Component.For<ICategoriaRepository>().ImplementedBy<CategoriaRepository>().LifeStyle.Transient);

            ComponentRegistration<IUnitOfWork> cr = Component.For<IUnitOfWork, UnitOfWork>().ImplementedBy<UnitOfWork>();           
            ComponentRegistration<IUnitOfWork> cr2 = slf.Suca(cr);
            container.Register(cr2);
        }
    }
}
