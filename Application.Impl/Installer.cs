using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Facilities.WcfIntegration;
using Ciccio1.Infrastructure;
using Ciccio1.Infrastructure.Conf;

namespace Ciccio1.Application.Impl
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            IConf conf = container.Resolve<IConf>();

            switch (conf.DataAccess)
            {
                case Storage.NHibernate:
                    container.Install(new Ciccio1.Infrastructure.Persistence.Nhb.Installer());
                    break;
                case Storage.Db4o:
                    //container.Install(new Ciccio1.Infrastructure.Persistence.Db4o.Installer());
                    break;
            }

            switch (conf.UserInterface)
            {
                case UI.Form:
                    container.Register(
                        Component.For<ICiccioService>().ImplementedBy<CiccioService>().LifestyleSingleton());
                    break;
                case UI.WPF:
                    container.Register(
                        Component.For<ICiccioService>().ImplementedBy<CiccioService>().LifestyleSingleton());
                    break;
                case UI.WCF:
                    container.Register(
                        //Component.For<ICiccioService>().ImplementedBy<CiccioService>().LifestylePerWcfSession());
                        //Component.For<ICiccioService>().ImplementedBy<CiccioService>().LifestylePerWcfOperation());
                        Component.For<ICiccioService>().ImplementedBy<CiccioService>().LifestyleTransient());
                    break;
                case UI.REST:
                    container.Register(
                        Component.For<ICiccioService>().ImplementedBy<CiccioService>().LifestylePerWebRequest()
                        );
                    break;
            }
        }
    }
}
